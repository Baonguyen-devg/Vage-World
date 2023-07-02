using UnityEngine;

namespace Group
{
    public class GroupDecorObject : Group
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            DecorObjectSpawner.Instance.SpawnInRegion
                (nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}