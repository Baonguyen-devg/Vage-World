using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public class GroupItem : Group
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            ItemSpawner.Instance.SpawnInRegion
                (nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}