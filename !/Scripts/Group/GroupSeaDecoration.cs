using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public class GroupSeaDecoration : Group
    {
        protected override bool IsGetLand(int x, int y)
        {
            if (mapController.CreateMap.GetSea(x, y) == null) return false;
            mapController.CreateMap.RemoveSea(x, y);
            return true;
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform objectDecor = SeaDecorationSpawner.Instance.Spawn(objectToSpawner);
            objectDecor.SetPositionAndRotation(position, rotation);
            objectDecor.gameObject.SetActive(true);
        }
    }
}