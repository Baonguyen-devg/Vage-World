using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : AutoMonobehaviour
{
    [Header("Adjusting the parameters of the map"), Space(10)]
    [SerializeField] private int heightMap = 50;
    [SerializeField] private int widthMap = 50;

    [SerializeField] private int randomFillPercent;
    [SerializeField] private int smoothPercent;
    [SerializeField] private int aligh;

    [Header("Sloving the creating map"), Space(10)]
    [SerializeField] private string seed = "Baonguyen.devG";
    [SerializeField] private MapController mapController;

    private bool[,] titles;
    private bool[,] colorTitles;

    private List<Transform> landList = new List<Transform>();
    private List<Transform> seaList = new List<Transform>();

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => mapController = GetComponentInParent<MapController>();

    protected override void Start()
    {
        titles = new bool[widthMap + 2, heightMap + 2];
        colorTitles = new bool[widthMap + 2, heightMap + 2];

        CreateBitRandom();
        SmoothMap();
        base.Start();
    }

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        CreateMapRandom();
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        mapController.DecorObject.CreateGroup();
        mapController.CreateSeaDecorObject.CreateGroup();
    }

    protected override IEnumerator LoadWaitForLongTime()
    {
        yield return StartCoroutine(base.LoadWaitForLongTime());
        mapController.CreateItem.CreateGroup();
          // mapController.CreateGroupEnemy.CreateGroup();
    }

    private void CreateBitRandom()
    {
        System.Random psuedo = GetPsude();

        for (int i = 0; i <= widthMap + 1; i++)
        for (int j = 0; j <= heightMap + 1; j++)
            if (Validation(i, j)) titles[i, j] = true;
            else titles[i, j] = (psuedo.Next(0, 100) < randomFillPercent);
    }

    private bool Validation(int i, int j) =>
        i <= aligh || j <= aligh || i >= widthMap + 1 - aligh || j >= heightMap + 1 - aligh;

    private System.Random GetPsude()
    {
        seed = System.DateTime.Now.ToString() + seed;
        System.Random psuedo = new System.Random(seed.GetHashCode());
        return psuedo;
    }

    private void CreateMapRandom()
    {
        Vector3 position = Vector3.zero;
        for (int i = 1; i <= widthMap; i++)
        for (int j = 1; j <= heightMap; j++)
        {
            Transform obj = null;
            if (!titles[i, j]) CreateLandDecoration(ref obj);
            else CreateSeaDecoration(ref obj, i, j);

            obj.gameObject.SetActive(true);
            (position.x, position.y) = (i - widthMap / 2, j - heightMap / 2);
            obj.position = position;
        }
    }

    private void CreateLandDecoration(ref Transform obj)
    {
        obj = LandDecorationSpawner.Instance.Spawn(LandDecorationSpawner.LAND_1);
        landList.Add(obj);
    }

    private void CreateSeaDecoration(ref Transform obj, int i, int j)
    {
        obj = SeaDecorationSpawner.Instance.Spawn(SeaDecorationSpawner.SEA_1);
        if (ChangeSide(i, j, obj)) seaList.Add(obj);
    }

    private bool ChangeSide(int x, int y, Transform sea)
    {
        Transform model = sea.Find("Model");

        if (x <= widthMap && y <= heightMap
            && !titles[x + 1, y + 1] && titles[x, y + 1] && titles[x + 1, y])
        {
            model.Find("EdgeLeftDown").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y <= heightMap 
            && !titles[x - 1, y + 1] && titles[x - 1, y] && titles[x, y + 1])
        {
            model.Find("EdgeRightDown").gameObject.SetActive(true);
            return false;
        }

        if (x <= widthMap && y - 1 >= 0
            && !titles[x + 1, y - 1] && titles[x, y - 1] && titles[x + 1, y])
        {
            model.Find("EdgeLeftUp").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y - 1 >= 0
            && !titles[x - 1, y - 1] && titles[x, y - 1] && titles[x - 1, y])
        {
            model.Find("EdgeRightUp").gameObject.SetActive(true);
            return false;
        }

        if (x <= widthMap && y - 1 >= 0
            && !titles[x + 1, y] && !titles[x, y - 1])
        {
            model.Find("RightDown").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y - 1 >= 0 && y <= heightMap
            && !titles[x - 1, y] && !titles[x, y - 1] && titles[x, y + 1])
        {
            model.Find("LeftDown").gameObject.SetActive(true);
            return false;
        }

        if (y <= heightMap && x <= widthMap
            && !titles[x, y + 1] && !titles[x + 1, y])
        {
            model.Find("RightUp").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y <= heightMap
            && !titles[x - 1, y] && !titles[x, y + 1])
        {
            model.Find("LeftUp").gameObject.SetActive(true);
            return false;
        }

        if (y - 1 >= 0 && !titles[x, y - 1])
        {
            model.Find("Bottom").gameObject.SetActive(true);
            return false;
        }

        if (y <= heightMap && !titles[x, y + 1])
        {
            model.Find("Top").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && !titles[x - 1, y])
        {
            model.Find("Left").gameObject.SetActive(true);
            return false;
        }

        if (x <= widthMap && !titles[x + 1, y])
        {
            model.Find("Right").gameObject.SetActive(true);
            return false;
        }

        model.Find("Center").gameObject.SetActive(true);
        return true;
    }

    private void SmoothMap()
    {
        for (int i = 1; i <= smoothPercent; i++)
        {
            Smooth(titles);
            Smooth(colorTitles);
        }
    }

    private void Smooth(bool[, ] smoothArray)
    {
        for (int i = aligh; i <= widthMap - aligh; i++)
        for (int j = aligh; j <= heightMap - aligh; j++)
            smoothArray[i, j] = (CountAround(i, j, smoothArray) > 4);
    }

    private int CountAround(int x, int y, bool[,] titles)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
        for (int j = y - 1; j <= y + 1; j++)
            count += titles[i, j] ? 1: 0;
        return count;
    }

    public virtual Transform GetObject(int X, int Y, List<Transform> objects)
    {
        Vector3 position = new Vector3(X, Y, 0);
        foreach (Transform obj in objects)
            if (obj.position == position) return obj;
        return null;
    }

    public virtual bool CheckSea(int x, int y) => titles[x, y];
    public virtual void RemoveLand(int X, int Y) => landList.Remove(GetObject(X, Y, landList));
    public virtual void RemoveSea(int X, int Y) => seaList.Remove(GetObject(X, Y, seaList));

    public virtual Transform GetLand(int X, int Y) => GetObject(X, Y, landList);
    public virtual Transform GetSea(int X, int Y) => GetObject(X, Y, seaList);

    public int HeightMap => heightMap;
    public int WidthMap => widthMap;

    public virtual List<Transform> GetLandList() => landList;
    public virtual List<Transform> GetSeaList() => seaList;
}
