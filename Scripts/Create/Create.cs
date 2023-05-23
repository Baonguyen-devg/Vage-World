using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : AutoMonobehaviour
{
    protected int[] col = { 0, 0, -1, 1 };
    protected int[] row = { -1, 1, 0, 0 };

    [SerializeField] protected int numberGroup;
    [SerializeField] protected int distanceMax;
    [SerializeField] protected bool[,] canPush;
    [SerializeField] protected MapController mapController;

    private int heightMap, widthMap;
    [SerializeField] protected string nameRegion;

    protected override void LoadComponent()
    {
        string region = transform.parent.name;
        this.nameRegion = region.Substring(9, region.Length - 9);
        base.LoadComponent();
        this.LoadMapController();
    }

    protected virtual void LoadMapController()
    {
        if (this.mapController != null) return;
        this.mapController = GetComponentInParent<MapController>();
        Debug.Log(transform.name + ": Load MapController", gameObject);
    }

    protected virtual void Start()
    {
        this.heightMap = this.mapController.CreateMap.HeightMap;
        this.widthMap = this.mapController.CreateMap.WidthMap;
    }

    public virtual void CreateGroup()
    {
        Debug.Log(transform.name + " " + this.numberGroup);
        this.canPush = new bool[this.widthMap + 1, this.heightMap + 1];
        for (int i = 1; i <= this.numberGroup; i++)
            this.Group();
    }

    protected virtual void Group()
    {
        List<Transform> listFake = this.mapController.CreateMap.landList;
        if (listFake.Count == 0)
        {
            Debug.Log("Don't enough space for the spawning group object");
            return;
        }

        int randomPosition = Random.Range(0, listFake.Count);

        Vector3 position = listFake[randomPosition].position;
        Quaternion rotation = listFake[randomPosition].rotation;

        this.SpawnObject(position, rotation);
        this.Spread(position);
    }

    protected virtual void SpawnObject(Vector3 position, Quaternion rotation)
    {
       
    }

    protected virtual void Spread(Vector3 position)
    {
        position = new Vector3(transform.parent.position.x + this.widthMap / 2, transform.parent.position.y + this.heightMap / 2, 0);
        Queue<Vector3> spreadland = new Queue<Vector3>();
        spreadland.Enqueue(position);
        while (spreadland.Count != 0)
        {
            Vector3 land = spreadland.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int posX = (int)land.x + this.col[i];
                int posY = (int)land.y + this.row[i];

                if (posX < 1 || posY < 1 || posX > this.widthMap || posY > this.heightMap) continue;
                if (this.CheckDistance(position, new Vector3(posX, posY, 0)) ||(this.canPush[posX, posY])) continue;
              
                this.canPush[posX, posY] = true;
                spreadland.Enqueue(new Vector3(posX, posY, 0));
            }
        }
    }

    protected virtual bool CheckDistance(Vector3 posTartget, Vector3 posPresent)
    {
        return (Vector3.Distance(posPresent, posTartget) > this.distanceMax);
    }
}
