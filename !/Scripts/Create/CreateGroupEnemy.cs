using UnityEngine;
using Group;
using System.Collections.Generic;

namespace CreatingPackage
{
    public class CreateGroupEnemy : Create
    {
        protected override void Group(int pointer)
        {
            List<Transform> listFake = this.mapController.CreateMap.landList;
            if (listFake.Count == 0) return;

            for (int i = 1; i <= this.resourceSpawners[pointer].Number; i++)
            {
                int randomPosition = Random.Range(minInclusive: 0, maxExclusive: listFake.Count);
                Transform objectSpawner = this.SpawnObject(position: listFake[randomPosition].position, rotation: listFake[randomPosition].rotation);
                objectSpawner.GetComponentInChildren<GroupEnemy>().
                    SetObjectSpawner(nameObject: this.resourceSpawners[pointer].NameResourceSpawner);
            }
        }

        protected override Transform SpawnObject(Vector3 position, Quaternion rotation) =>
            GroupEnemySpawner.Instance.SpawnInRegion
                (nameObject: GroupEnemySpawner.pointSpawn_1, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}