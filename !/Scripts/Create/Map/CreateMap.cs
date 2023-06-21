using System.Collections.Generic;
using UnityEngine;

public class CreateMap : AutoMonobehaviour
{
    protected int[] col = { 0, 1, -1, 0, 0, 1, 1, -1, -1 };
    protected int[] row = { -1, 0, 0, 1, 0, -1, 1, 1, -1 };
    [SerializeField] protected int heightMap = 50;
    [SerializeField] protected int widthMap = 50;
    [SerializeField] protected int randomFillPercent;
    [SerializeField] protected int smoothPercent;
    [SerializeField] protected int rateChangeColor;

    [SerializeField] protected int[,] titles;
    [SerializeField] protected int[,] colorTitles;
    [SerializeField] protected string seed = "Baonguyen.devG";
    [SerializeField] protected MapController mapController;

    public List<Transform> landList;
    [SerializeField] private LevelManagerSO levelManagerSO;

    public int HeightMap => this.heightMap;
    public int WidthMap => this.widthMap;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMapController();
        this.LoadLevelManagerSO();
    }

    protected virtual void LoadLevelManagerSO()
    {
        if (this.levelManagerSO != null) return;
        string resPath = "Level/EasyLevel";
        this.levelManagerSO = Resources.Load<LevelManagerSO>(resPath);
        Debug.LogWarning(transform.name + ": Load GroupDecorObjectSO" + resPath, gameObject);
        this.LoadInformationMap();
    }

    protected virtual void LoadInformationMap()
    {
        this.widthMap = this.levelManagerSO.Width;
        this.heightMap = this.levelManagerSO.Height;
        this.smoothPercent = this.levelManagerSO.Smooth;
        this.randomFillPercent = this.levelManagerSO.RandomFillPercent;
        this.rateChangeColor = this.levelManagerSO.RateChangeColor;
    }

    protected virtual void Start()
    {
        string region = transform.parent.name;
        this.CreateBitRandom();
        this.SmoothMap();


        this.CreateMapRandom();
        this.mapController.CreateGroupEnemy.CreateGroup();
        /* this.CreateObjectInMap();*/
        /* this.CreateLink();*/
    }

    public virtual void CreateObjectInMap()
    {
        this.mapController.DecorObject.CreateGroup();
        this.mapController.CreateItem.CreateGroup();
    }

    protected virtual void CreateLink()
    {
        Transform portal_1 = this.mapController.Link.Find("InPortal");
        Transform portal_2 = this.mapController.Link.Find("OutPortal");

        this.ChangePosPortal(portal_1);
        this.ChangePosPortal(portal_2);
    }

    protected virtual void ChangePosPortal(Transform portal)
    {
        int key = Random.Range(0, this.landList.Count);
        portal.position = this.landList[key].position;
        this.RemoveLand((int)(this.landList[key].position.x + this.widthMap / 2), (int)(this.landList[key].position.y + this.heightMap / 2));
    }

    protected virtual void LoadMapController()
    {
        if (this.mapController != null) return;
        this.mapController = GetComponentInParent<MapController>();
        Debug.Log(transform.name + ": Load MapController", gameObject);
    }

    public virtual void AddLand(Transform land) => this.landList.Add(land);

    public virtual void RemoveLand(int posX, int posY)
    {
        Transform land = this.GetLand(posX, posY);
        this.landList.Remove(land);
    }

    public virtual Transform GetLand(int X, int Y)
    {
        foreach (Transform land in this.landList)
            if (land.position == new Vector3(X, Y, 0)) return land;
        return null;
    }

    protected virtual void CreateBitRandom()
    {
        this.seed = System.DateTime.Now.ToString() + this.seed;
        this.titles = new int[this.widthMap + 2, this.heightMap + 2];
        this.colorTitles = new int[this.widthMap + 2, this.heightMap + 2];
        System.Random psuedo = new System.Random(this.seed.GetHashCode());

        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                if (i <= 2 || j <= 2 || i >= this.widthMap - 1 || j >= this.heightMap - 1) this.titles[i, j] = 1;
                else this.titles[i, j] = (psuedo.Next(0, 100) < this.randomFillPercent) ? 1 : 0;

                if (this.titles[i, j] == 0 && Random.Range(0, 10) <= this.rateChangeColor) this.colorTitles[i, j] = 1;
            }
    }

    protected virtual void CreateMapRandom()
    {
        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                Vector3 pos = new Vector3(i - this.widthMap / 2, j - this.heightMap / 2, 0);
                Quaternion rot = transform.rotation;

                Transform land = null, sea = null;
                if (this.titles[i, j] == 0) land = MapSpawner.Instance.SpawnInRegion(MapSpawner.land_1, "Forest", pos, rot);
                else sea = MapSpawner.Instance.SpawnInRegion(MapSpawner.sea_1, "Forest", pos, rot);
                if (land == null)
                {
                    this.ChangeSide(i, j, sea);
                    continue;
                }
                if (this.titles[i, j] == 0) this.landList.Add(land);
                if (this.colorTitles[i, j] == 1) this.ChangeColor(land);
            }
    }

    protected virtual void ChangeSide(int x, int y, Transform sea)
    {
        Transform model = sea.Find("Model");

        if (y >= 1 && this.titles[x, y - 1] == 0)
        {
            model.Find("Bottom").gameObject.SetActive(true);
            return;
        }

        if (y <= this.heightMap && this.titles[x, y + 1] == 0)
        {
            model.Find("Top").gameObject.SetActive(true);
            return;
        }

        model.Find("Center").gameObject.SetActive(true);
    }

    protected virtual void ChangeColor(Transform land)
    {
        SpriteRenderer SRender = land.Find("Model").GetComponent<SpriteRenderer>();
        SRender.color = new Color(SRender.color.r, SRender.color.g, SRender.color.b, 0.8f);
        SpriteRenderer SMMRender = land.Find("MiniMap").GetComponent<SpriteRenderer>();
        SMMRender.color = new Color(SMMRender.color.r, SMMRender.color.g, SMMRender.color.b, 0.8f);
    }

    protected virtual void SmoothMap()
    {
        for (int i = 0; i < this.smoothPercent; i++)
            this.Smooth();
    }

    protected virtual void Smooth()
    {
        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                int numberLandAround = this.LandAround(i, j);

                if (numberLandAround > 4) this.titles[i, j] = 1;
                else this.titles[i, j] = 0;
            }

        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                int numberColorLandAround = this.ColorAround(i, j);

                if (numberColorLandAround > 4) this.colorTitles[i, j] = 1;
                else this.colorTitles[i, j] = 0;
            }
    }

    public virtual bool CheckSea(int x, int y)
    {
        return (this.titles[x, y] == 1);
    }

    protected virtual int LandAround(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
            for (int j = y - 1; j <= y + 1; j++)
                count = count + this.titles[i, j];
        return count;
    }

    protected virtual int ColorAround(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
            for (int j = y - 1; j <= y + 1; j++)
                count = count + this.colorTitles[i, j];
        return count;
    }
}
