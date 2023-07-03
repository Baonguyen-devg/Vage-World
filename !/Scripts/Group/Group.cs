using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public abstract class Group : AutoMonobehaviour
    {
        protected int[] col = { 0, 0, -1, 1 };
        protected int[] row = { -1, 1, 0, 0 };

        [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
        [SerializeField] protected LevelManagerSO levelManagerSO = default;
        protected virtual void LoadLevelManagerSO() =>
             this.levelManagerSO ??= Resources.Load<LevelManagerSO>(path: "Level/EasyLevel");

        [Range(min: 0, max: 50), SerializeField] protected int numberObject;
        [SerializeField] protected string objectSpawner;
        [SerializeField] protected Queue<Vector2> landList;

        [SerializeField] protected MapController mapController;
        protected virtual void LoadMapController() =>
            this.mapController ??= GameObject.Find(name: "CreateMapForest").GetComponent<MapController>();

        protected override void LoadComponent()
        {
            this.LoadLevelManagerSO();
            this.LoadMapController();
        }

        public virtual void SetObjectSpawner(string nameObject)
        {
            this.objectSpawner = nameObject;
            this.CreateObject(position: transform.parent.position);
        }

        protected virtual void CreateObject(Vector3 position)
        {
            int count = 0;
            this.landList = new Queue<Vector2>();
            landList.Enqueue(item: position);
            while (count <= this.numberObject && landList.Count != 0)
            {
                Vector3 pos = landList.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = (int)pos.x + col[i], y = (int)pos.y + row[i];
                    if (this.mapController.CreateMap.GetLand(X: x, Y: y) == null) continue;
                    if (++count > this.numberObject) break;

                    this.mapController.CreateMap.RemoveLand(posX: x, posY: y);
                    landList.Enqueue(item: new Vector2(x, y));
                    this.SpawnObject(position: new Vector2(x, y), rotation: transform.parent.rotation);
                }
            }
        }

        protected abstract void SpawnObject(Vector3 position, Quaternion rotation);
    }
}