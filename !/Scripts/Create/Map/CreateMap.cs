using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateMap : AutoMonobehaviour
{
    protected int[] col = { 0, 1, -1, 0, 0, 1, 1, -1, -1 };
    protected int[] row = { -1, 0, 0, 1, 0, -1, 1, 1, -1 };

    [Header(header: "Adjusting the parameters of the map"), Space(height: 10)]
    [SerializeField] protected int heightMap = 50;
    public int HeightMap => this.heightMap;

    [SerializeField] protected int widthMap = 50;
    public int WidthMap => this.widthMap;

    [SerializeField] protected int randomFillPercent;
    [SerializeField] protected int smoothPercent;
  
    [Header(header: "Sloving the creating map"), Space(height: 10)]
    [SerializeField] protected int[,] titles;
    [SerializeField] protected int[,] colorTitles;
    [SerializeField] protected string seed = "Baonguyen.devG";

    [SerializeField] protected MapController mapController;
    protected virtual void LoadMapController() =>
      this.mapController ??= GetComponentInParent<MapController>();

    public List<Transform> landList;
    public List<Transform> seaList;

    [Header(header: "Scriptable Object LevelManager"), Space(height: 10)]
    [SerializeField] private LevelManagerSO levelManagerSO;
    protected virtual void LoadLevelManagerSO() =>
        this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

    protected override void LoadComponent() => this.LoadMapController();

    protected virtual void LoadInformationMap()
    {
        this.widthMap = this.levelManagerSO.Width;
        this.heightMap = this.levelManagerSO.Height;
        this.smoothPercent = this.levelManagerSO.Smooth;
        this.randomFillPercent = this.levelManagerSO.RandomFillPercent;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadLevelManagerSO();
        this.LoadInformationMap();
    }

    protected override void Start()
    {
        this.CreateBoneMap();  
        base.Start();
    }

    protected virtual void CreateBoneMap()
    {
        this.CreateBitRandom();
        this.SmoothMap();
    }

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        this.CreateMapRandom();
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        this.mapController.DecorObject.CreateGroup();
        this.mapController.CreateSeaDecorObject.CreateGroup();
    }

    protected override IEnumerator LoadWaitForLongTime()
    {
        yield return StartCoroutine(base.LoadWaitForLongTime());
        this.mapController.CreateItem.CreateGroup();
        this.mapController.CreateGroupEnemy.CreateGroup();
    }

    public virtual void RemoveLand(int posX, int posY) =>
        this.landList.Remove(item: this.GetLand(X: posX, Y: posY));

    public virtual void RemoveSea(int posX, int posY) =>
     this.landList.Remove(item: this.GetSea(X: posX, Y: posY));

    public virtual Transform GetLand(int X, int Y)
    {
        foreach (Transform land in this.landList)
            if (land.position == new Vector3(X, Y, 0)) return land;
        return null;
    }

    public virtual Transform GetSea(int X, int Y)
    {
        foreach (Transform sea in this.seaList)
            if (sea.position == new Vector3(X, Y, 0)) return sea;
        return null;
    }

    protected virtual void CreateBitRandom()
    {
        this.seed = System.DateTime.Now.ToString() + this.seed;
        this.titles = new int[this.widthMap + 2, this.heightMap + 2];
        this.colorTitles = new int[this.widthMap + 2, this.heightMap + 2];
        System.Random psuedo = new System.Random(Seed: this.seed.GetHashCode());

        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                if (i <= 2 || j <= 2 || i >= this.widthMap - 1 || j >= this.heightMap - 1) this.titles[i, j] = 1;
                else this.titles[i, j] = (psuedo.Next(minValue: 0, maxValue: 100) < this.randomFillPercent) ? 1 : 0;
            }
    }

    protected virtual void CreateMapRandom()
    {
        for (int i = 2; i < this.widthMap; i++)
            for (int j = 2; j < this.heightMap; j++)
            {
                Vector3 pos = new Vector3(i - this.widthMap / 2, j - this.heightMap / 2, 0);
                Quaternion rot = transform.rotation;

                Transform land = null, sea = null;
                if (this.titles[i, j] == 0) 
                    land = MapSpawner.Instance.SpawnInRegion(nameObject: MapSpawner.land_1, nameRegion: "Forest", postion: pos, rotation: rot);
                else 
                    sea = MapSpawner.Instance.SpawnInRegion(nameObject: MapSpawner.sea_1, nameRegion: "Forest", postion: pos, rotation: rot);
                if (land == null)
                {
                    if (this.ChangeSide(x: i, y: j, sea: sea))
                        this.seaList.Add(item: sea);
                    continue;
                }
                if (this.titles[i, j] == 0) this.landList.Add(item: land);
            }
    }

    protected virtual bool ChangeSide(int x, int y, Transform sea)
    {
        Transform model = sea.Find(n: "Model");

        if (this.titles[x + 1, y + 1] == 0 && this.titles[x, y + 1] == 1 && this.titles[x + 1, y] == 1)
        {
            model.Find(n: "EdgeLeftDown").gameObject.SetActive(value: true);
            return false;

        }

        if (this.titles[x - 1, y + 1] == 0 && this.titles[x - 1, y] == 1 && this.titles[x, y + 1] == 1)
        {
            model.Find(n: "EdgeRightDown").gameObject.SetActive(value: true);
            return false;

        }

        if (this.titles[x + 1, y - 1] == 0 && this.titles[x, y - 1] == 1 && this.titles[x + 1, y] == 1)
        {
            model.Find(n: "EdgeLeftUp").gameObject.SetActive(value: true);
            return false;

        }

        if (this.titles[x - 1, y - 1] == 0 && this.titles[x, y - 1] == 1 && this.titles[x - 1, y] == 1)
        {
            model.Find(n: "EdgeRightUp").gameObject.SetActive(value: true);
            return false;

        }

        if (this.titles[x + 1, y] == 0 && this.titles[x, y - 1] == 0 && this.titles[x, y + 1] != 0)
        {
            model.Find(n: "RightDown").gameObject.SetActive(value: true);
            return false;
        }

        if (this.titles[x - 1, y] == 0 && this.titles[x, y - 1] == 0 && this.titles[x, y + 1] != 0)
        {
            model.Find(n: "LeftDown").gameObject.SetActive(value: true);
            return false;
        }

        if (this.titles[x, y + 1] == 0 && this.titles[x + 1, y] == 0)
        {
            model.Find(n: "RightUp").gameObject.SetActive(value: true);
            return false;
        }

        if (this.titles[x - 1, y] == 0 && this.titles[x, y + 1] == 0)
        {
            model.Find(n: "LeftUp").gameObject.SetActive(value: true);
            return false;
        }


        if (y >= 1 && this.titles[x, y - 1] == 0)
        {
            model.Find(n: "Bottom").gameObject.SetActive(value: true);
            return false;
        }

        if (y <= this.heightMap && this.titles[x, y + 1] == 0)
        {
            model.Find(n: "Top").gameObject.SetActive(value: true);
            return false;
        }

        if (x >= 1 && this.titles[x - 1, y] == 0)
        {
            model.Find(n: "Left").gameObject.SetActive(value: true);
            return false;
        }

        if (x <= this.widthMap && this.titles[x + 1, y] == 0)
        {
            model.Find(n: "Right").gameObject.SetActive(value: true);
            return false;
        }

        model.Find(n: "Center").gameObject.SetActive(value: true);
        return true;
    }

    protected virtual void SmoothMap()
    {
        for (int i = 1; i <= this.smoothPercent; i++)
        {
            this.Smooth(smoothArray: this.titles);
            this.Smooth(smoothArray: this.colorTitles);
        }
    }

    protected virtual void Smooth(int[, ] smoothArray)
    {
        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
                if (this.CountAround(x: i, y: j, titles: smoothArray) > 4) smoothArray[i, j] = 1;
                else smoothArray[i, j] = 0;
    }

    public virtual bool CheckSea(int x, int y) => (this.titles[x, y] == 1);

    protected virtual int CountAround(int x, int y, int[,] titles)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
            for (int j = y - 1; j <= y + 1; j++)
                count += titles[i, j];
        return count;
    }

}
