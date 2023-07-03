using UnityEngine;

namespace Group
{
    public class GroupEnemy : Group
    {
        public override void SetObjectSpawner(string nameObject)
        {
            this.objectSpawner = nameObject;
            this.numberObject = this.levelManagerSO.GetEnemySOByName(nameObject).NumberObject;
            this.CreateObject(position: transform.parent.position);
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform enemy = EnemySpawner.Instance.SpawnInRegion(nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
            transform.parent.GetComponent<PointSpawnEnemy>().Add(enemy: enemy);
        }
    }
}