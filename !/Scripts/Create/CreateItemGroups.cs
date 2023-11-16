using System.Collections.Generic;
using UnityEngine;
using Group;

namespace CreatingPackage
{
    public class CreateItemGroups : BaseCreateGroups<GroupItem>
    {
        protected override string GetPath() => "Group/GroupSpawn_Item";
        protected override List<Transform> GetAllLandInMap() => mapController.CreateMap.GetLandList();

        protected override Transform SpawnGroup(Vector3 position, Quaternion rotation)
        {
            Transform group = GroupSpawner.Instance.Spawn(GroupSpawner.ITEM);
            group.gameObject.SetActive(true);
            group.SetPositionAndRotation(position, rotation);
            return group;
        }
    }
}