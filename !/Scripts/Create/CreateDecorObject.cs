using UnityEngine;

namespace CreatingPackage
{
    public class CreateDecorObject : Create
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            GroupDecorObjectSpawner.Instance?.SpawnInRegion
                (GroupDecorObjectSpawner.pointSpawn_1, "Forest", position, rotation);
    }
}