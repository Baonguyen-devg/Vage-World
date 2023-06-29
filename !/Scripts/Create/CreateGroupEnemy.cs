using UnityEngine;

namespace CreatingPackage
{
    public class CreateGroupEnemy : Create
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            GroupEnemySpawner.Instance.SpawnInRegion
                (GroupEnemySpawner.pointSpawn_1, "Forest", position, rotation);
    }
}