using UnityEngine;

namespace Group
{
    public class GroupDecorObject : Group
    {
        public override void SetObjectSpawner(string nameObject)
        {
            this.objectSpawner = nameObject;
            this.numberObject = this.levelManagerSO.GetDecorSOByName(nameObject).NumberObject;
            this.CreateObject(position: transform.parent.position);
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            DecorObjectSpawner.Instance.SpawnInRegion
                (nameObject: this.objectSpawner, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}