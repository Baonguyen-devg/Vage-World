using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : AutoMonobehaviour
{
    [Header("Adjusting the parameters of the map"), Space(10)]
    [SerializeField] private int _heightMap = 50;
    [SerializeField] private int _widthMap = 50;
    [SerializeField] private int _aligh;

    [Range(0, 100), SerializeField] private int _randomFillPercent;
    [Range(0, 10), SerializeField] private int _smoothPercent;

    private string _seed = "Baonguyen.devG";
    private MapController _mapController;

    private bool[,] _titles;
    private bool[,] _colorTitles;

    private List<Transform> _landList = new List<Transform>();
    private List<Transform> _seaList = new List<Transform>();

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent() => _mapController = GetComponentInParent<MapController>();

    protected override void Start()
    {
        _titles = new bool[_widthMap + 2, _heightMap + 2];
        _colorTitles = new bool[_widthMap + 2, _heightMap + 2];

        CreateBitRandom();
        SmoothMap();
        base.Start();
    }
    #endregion

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        CreateMapRandom();
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        _mapController.CreateGroupEnemy.CreateGroup();
    }

    protected override IEnumerator LoadWaitForLongTime()
    {
        yield return StartCoroutine(base.LoadWaitForLongTime());
        _mapController.DecorObject.CreateGroup();
        _mapController.CreateSeaDecorObject.CreateGroup();
        _mapController.CreateItem.CreateGroup();
    }

    private void CreateBitRandom()
    {
        System.Random psuedo = GetPsude();

        for (int i = 0; i <= _widthMap + 1; i++)
            for (int j = 0; j <= _heightMap + 1; j++)
                if (Validation(i, j)) _titles[i, j] = true;
                else _titles[i, j] = (psuedo.Next(0, 100) < _randomFillPercent);
    }

    private bool Validation(int i, int j) =>
        i <= _aligh || j <= _aligh || i >= _widthMap + 1 - _aligh || j >= _heightMap + 1 - _aligh;

    private System.Random GetPsude()
    {
        _seed = System.DateTime.Now.ToString() + _seed;
        System.Random psuedo = new System.Random(_seed.GetHashCode());
        return psuedo;
    }

    private void CreateMapRandom()
    {
        Vector3 position = Vector3.zero;
        for (int i = 1; i <= _widthMap; i++)
            for (int j = 1; j <= _heightMap; j++)
            {
                Transform obj = null;
                if (!_titles[i, j]) CreateLandDecoration(ref obj);
                else CreateSeaDecoration(ref obj, i, j);

                obj.gameObject.SetActive(true);
                (position.x, position.y) = (i - _widthMap / 2, j - _heightMap / 2);
                obj.position = position;
            }
    }

    private void CreateLandDecoration(ref Transform obj)
    {
        obj = LandDecorationSpawner.Instance.Spawn(LandDecorationSpawner.LAND_1);
        _landList.Add(obj);
    }

    private void CreateSeaDecoration(ref Transform obj, int i, int j)
    {
        obj = SeaDecorationSpawner.Instance.Spawn(SeaDecorationSpawner.SEA_1);
        if (ChangeSide(i, j, obj)) _seaList.Add(obj);
    }

    private bool ChangeSide(int x, int y, Transform sea)
    {
        Transform model = sea.Find("Model");

        if (x <= _widthMap && y <= _heightMap
            && !_titles[x + 1, y + 1] && _titles[x, y + 1] && _titles[x + 1, y])
        {
            model.Find("EdgeLeftDown").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y <= _heightMap
            && !_titles[x - 1, y + 1] && _titles[x - 1, y] && _titles[x, y + 1])
        {
            model.Find("EdgeRightDown").gameObject.SetActive(true);
            return false;
        }

        if (x <= _widthMap && y - 1 >= 0
            && !_titles[x + 1, y - 1] && _titles[x, y - 1] && _titles[x + 1, y])
        {
            model.Find("EdgeLeftUp").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y - 1 >= 0
            && !_titles[x - 1, y - 1] && _titles[x, y - 1] && _titles[x - 1, y])
        {
            model.Find("EdgeRightUp").gameObject.SetActive(true);
            return false;
        }

        if (x <= _widthMap && y - 1 >= 0
            && !_titles[x + 1, y] && !_titles[x, y - 1])
        {
            model.Find("RightDown").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y - 1 >= 0 && y <= _heightMap
            && !_titles[x - 1, y] && !_titles[x, y - 1] && _titles[x, y + 1])
        {
            model.Find("LeftDown").gameObject.SetActive(true);
            return false;
        }

        if (y <= _heightMap && x <= _widthMap
            && !_titles[x, y + 1] && !_titles[x + 1, y])
        {
            model.Find("RightUp").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && y <= _heightMap
            && !_titles[x - 1, y] && !_titles[x, y + 1])
        {
            model.Find("LeftUp").gameObject.SetActive(true);
            return false;
        }

        if (y - 1 >= 0 && !_titles[x, y - 1])
        {
            model.Find("Bottom").gameObject.SetActive(true);
            return false;
        }

        if (y <= _heightMap && !_titles[x, y + 1])
        {
            model.Find("Top").gameObject.SetActive(true);
            return false;
        }

        if (x - 1 >= 0 && !_titles[x - 1, y])
        {
            model.Find("Left").gameObject.SetActive(true);
            return false;
        }

        if (x <= _widthMap && !_titles[x + 1, y])
        {
            model.Find("Right").gameObject.SetActive(true);
            return false;
        }

        model.Find("Center").gameObject.SetActive(true);
        return true;
    }

    private void SmoothMap()
    {
        for (int i = 1; i <= _smoothPercent; i++)
        {
            Smooth(_titles);
            Smooth(_colorTitles);
        }
    }

    private void Smooth(bool[,] smoothArray)
    {
        for (int i = _aligh; i <= _widthMap - _aligh; i++)
            for (int j = _aligh; j <= _heightMap - _aligh; j++)
                smoothArray[i, j] = (CountAround(i, j, smoothArray) > 4);
    }

    private int CountAround(int x, int y, bool[,] titles)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
            for (int j = y - 1; j <= y + 1; j++)
                count += titles[i, j] ? 1 : 0;
        return count;
    }

    public virtual Transform GetObject(int X, int Y, List<Transform> objects)
    {
        Vector3 position = new Vector3(X, Y, 0);
        foreach (Transform obj in objects)
            if (obj.position == position) return obj;
        return null;
    }

    public virtual bool CheckSea(int x, int y) => _titles[x, y];
    public virtual void RemoveLand(int X, int Y) => _landList.Remove(GetObject(X, Y, _landList));
    public virtual void RemoveSea(int X, int Y) => _seaList.Remove(GetObject(X, Y, _seaList));

    public virtual Transform GetLand(int X, int Y) => GetObject(X, Y, _landList);
    public virtual Transform GetSea(int X, int Y) => GetObject(X, Y, _seaList);

    public int HeightMap => _heightMap;
    public int WidthMap => _widthMap;

    public virtual List<Transform> GetLandList() => _landList;
    public virtual List<Transform> GetSeaList() => _seaList;
    public virtual Transform GetRandomLand()
    {
        int random = _landList[Random.Range(0, _landList.Count)].gameObject.GetInstanceID();
        return _landList[Mathf.Abs(random) % _landList.Count];
    }
}
