using UnityEngine;

namespace Group
{
    public class GroupEnemy : Group
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform enemy = EnemySpawner.Instance.SpawnInRegion(nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
            transform.parent.GetComponent<PointSpawnEnemy>().Add(enemy: enemy);
        }
    }
}