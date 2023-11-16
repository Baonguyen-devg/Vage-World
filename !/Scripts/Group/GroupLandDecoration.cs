using UnityEngine;

namespace Group
{
    public class GroupLandDecoration : Group
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform objectDecor = LandDecorationSpawner.Instance.Spawn(objectToSpawner);
            objectDecor.SetPositionAndRotation(position, rotation);
            objectDecor.gameObject.SetActive(true);
        }
    }
}
