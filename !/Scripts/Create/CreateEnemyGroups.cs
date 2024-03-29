using System.Collections.Generic;
using UnityEngine;
using Group;

namespace CreatingPackage
{
    public class CreateEnemyGroups : BaseCreateGroups<GroupEnemy>
    {
        protected override string GetPath()
        {
            string level = "Level " + DataManager.GetIntData(DataManager.INT_LEVEL);
            string path = "Level/" + level + "/GroupSpawn_Enemy";
            Debug.Log(path);
            return path;
        }
        protected override List<Transform> GetAllLandInMap() => mapController.CreateMap.GetLandList();

        protected override Transform SpawnGroup(Vector3 position, Quaternion rotation)
        {
            Transform group = GroupSpawner.Instance.Spawn(GroupSpawner.ENEMY);
            group.gameObject.SetActive(true);
            group.SetPositionAndRotation(position, rotation);
            return group;
        }
}
}