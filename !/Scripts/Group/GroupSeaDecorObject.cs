using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public class GroupSeaDecorObject : Group
    {
        [SerializeField] protected Queue<Vector2> seaList;

        public override void SetObjectSpawner(string nameObject)
        {
            this.objectSpawner = nameObject;
            this.numberObject = this.levelManagerSO.GetSeaDecorSOByName(nameObject).NumberObject;
            this.CreateObject(position: transform.parent.position);
        }

        protected override void CreateObject(Vector3 position)
        {
            int count = 0;
            this.seaList = new Queue<Vector2>();
            seaList.Enqueue(item: position);
            while (count <= this.numberObject && seaList.Count != 0)
            {
                Vector3 pos = seaList.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = (int)pos.x + col[i], y = (int)pos.y + row[i];
                    if (this.mapController.CreateMap.GetSea(X: x, Y: y) == null) continue;
                    if (++count > this.numberObject) break;

                    this.mapController.CreateMap.RemoveSea(posX: x, posY: y);
                    seaList.Enqueue(item: new Vector2(x, y));
                    this.SpawnObject(position: new Vector2(x, y), rotation: transform.parent.rotation);
                }
            }
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            SeaDecorObjectSpawner.Instance.SpawnInRegion
                (nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}