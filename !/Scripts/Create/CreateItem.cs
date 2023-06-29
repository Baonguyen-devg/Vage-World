using UnityEngine;

namespace CreatingPackage
{
    public class CreateItem : Create
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            GroupItemSpawner.Instance?.SpawnInRegion
                (GroupItemSpawner.pointSpawn_1, "Forest", position, rotation);
    }
}