using System.Collections.Generic;
using UnityEngine;
using Group;

namespace CreatingPackage
{
    public class CreateLandDecorationGroups : BaseCreateGroups<GroupLandDecoration>
    {
        protected override string GetPath()
        {
            string level = "Level " + DataManager.GetIntData(DataManager.INT_LEVEL);
            string path = "Level/" + level + "/GroupSpawn_Land_Decoration";
            return path;
        }
      
        protected override List<Transform> GetAllLandInMap() => mapController.CreateMap.GetLandList();

        protected override Transform SpawnGroup(Vector3 position, Quaternion rotation)
        {
            Transform group = GroupSpawner.Instance.Spawn(GroupSpawner.LAND_DECORATION);
            group.gameObject.SetActive(true);
            group.SetPositionAndRotation(position, rotation);
            return group;
        }
    }
}