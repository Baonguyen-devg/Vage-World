using System.Collections.Generic;
using UnityEngine;
using Group;

namespace CreatingPackage
{
    public class CreateSeaDecorationGroups : BaseCreateGroups<GroupSeaDecoration>
    {
        protected override string GetPath() => "Group/GroupSpawn_Sea_Decoration";
        protected override List<Transform> GetAllLandInMap() => mapController.CreateMap.GetSeaList();

        protected override Transform SpawnGroup(Vector3 position, Quaternion rotation)
        {
            Transform group = GroupSpawner.Instance.Spawn(GroupSpawner.SEA_DECORATION);
            group.gameObject.SetActive(true);
            group.SetPositionAndRotation(position, rotation);
            return group;
        }
    }
}