using UnityEngine;

namespace Group
{
    public class GroupEnemy : Group
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform enemy = EnemySpawner.Instance.Spawn(objectToSpawner);
            enemy.SetPositionAndRotation(position, rotation);
            enemy.gameObject.SetActive(true);
            transform.parent.GetComponent<PointSpawnEnemy>().Add(enemy);
        }
    }
}