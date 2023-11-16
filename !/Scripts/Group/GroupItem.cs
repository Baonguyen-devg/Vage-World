using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public class GroupItem : Group
    {
        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform item = ItemSpawner.Instance.Spawn(objectToSpawner);
            item.SetPositionAndRotation(position, rotation);
            item.gameObject.SetActive(true);
        }
    }
}