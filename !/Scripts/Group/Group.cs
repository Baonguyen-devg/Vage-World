using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public abstract class Group : AutoMonobehaviour
    {
        protected int[] col = { 0, 0, -1, 1 };
        protected int[] row = { -1, 1, 0, 0 };

        [SerializeField] protected int numberObject;
        [SerializeField] protected string objectSpawner;
        [SerializeField] protected Queue<Vector2> landList;

        [SerializeField] protected MapController mapController;
        protected virtual void LoadMapController() =>
            this.mapController ??= GameObject.Find("CreateMapForest").GetComponent<MapController>();

        [Header("Spawning Number")]
        [SerializeField] protected int minNumber = 5;
        [SerializeField] protected int maxNumber = 7;

        protected override void LoadComponent() => this.LoadMapController();

        protected override void Awake()
        {
            this.landList = new Queue<Vector2>();
            this.numberObject = Random.Range(this.minNumber, this.maxNumber);
            this.CreateObject(transform.parent.position);
        }

        protected virtual void CreateObject(Vector3 position)
        {
            int count = 0;
            landList.Enqueue(position);
            while (count <= this.numberObject && landList.Count != 0)
            {
                Vector3 pos = landList.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = (int)pos.x + col[i], y = (int)pos.y + row[i];
                    if (this.mapController.CreateMap.GetLand(x, y) == null) continue;
                    if (++count > this.numberObject) break;

                    this.mapController.CreateMap.RemoveLand(x, y);
                    landList.Enqueue(new Vector2(x, y));
                    this.SpawnObject(new Vector2(x, y), transform.parent.rotation);
                }
            }
        }

        protected abstract void SpawnObject(Vector3 position, Quaternion rotation);
    }
}