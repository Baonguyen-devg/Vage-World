using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public class GroupItem : Group
    {
        public override void SetObjectSpawner(string nameObject)
        {
            this.objectSpawner = nameObject;
            this.numberObject = this.levelManagerSO.GetItemSOByName(nameObject).NumberObject;
            this.CreateObject(position: transform.parent.position);
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            ItemSpawner.Instance.SpawnInRegion
                (nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}