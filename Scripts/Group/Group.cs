using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : AutoMonobehaviour
{
    protected int[] col = { 0, 0, -1, 1, 0 };
    protected int[] row = { -1, 1, 0, 0, 0 };

    [SerializeField] protected int numberObject;
    [SerializeField] protected bool[,] haveObject;
    [SerializeField] protected string objectSpawner;
    [SerializeField] protected MapController mapController;
    [SerializeField] protected string nameRegion;

    [Header("Spawning Number")]
    [SerializeField] protected int minNumber = 3;
    [SerializeField] protected int maxNumber = 4;

    public virtual void ChangeMapController(MapController map)
    {
        this.mapController = map;
        string region = this.mapController.name;
        this.nameRegion = region.Substring(9, region.Length - 9);

        this.numberObject = Random.Range(this.minNumber, this.maxNumber);
        this.CreateObject(transform.parent.position);
    }

    protected virtual void CreateObject(Vector3 position)
    {
        int count = 0;
        position = new Vector3(position.x, position.y, 0);

        Queue<Vector3> landList = new Queue<Vector3>();
        landList.Enqueue(position);
        while (count != this.numberObject && landList.Count != 0)
        {
            Vector3 pos = landList.Dequeue();
            for (int i = 0; i < 5; i++)
            {
                int x = (int)pos.x + col[i];
                int y = (int)pos.y + row[i];
                if (this.mapController.CreateMap.GetLand(x, y) == null) continue;
                if (++count > this.numberObject) break;

                this.mapController.CreateMap.RemoveLand(x, y);
                landList.Enqueue(new Vector3(x, y, 0));

                Vector3 posGroup = new Vector3(x, y, 0);
                Quaternion rotGroup = transform.parent.rotation;
                this.SpawnObject(posGroup, rotGroup);
            }

        }
    }

    protected virtual void SpawnObject(Vector3 position, Quaternion rotation)
    {
       //For override
    }

    protected virtual bool CheckPos(int x, int y)
    {
        int width = this.mapController.CreateMap.WidthMap;
        int height = this.mapController.CreateMap.HeightMap;

        if (x < 1 || y < 1 || x > width || y > height) return false;
        if (this.mapController.CreateMap.CheckSea(x, y)) return false;
        return true;
    }
}
