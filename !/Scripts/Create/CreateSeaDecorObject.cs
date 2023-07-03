using System.Collections.Generic;
using UnityEngine;
using Group;

namespace CreatingPackage
{
    public class CreateSeaDecorObject : Create
    {
        protected override void Group(int pointer)
        {
            List<Transform> listFake = this.mapController.CreateMap.seaList;
            if (listFake.Count == 0) return;

            for (int i = 1; i <= this.resourceSpawners[pointer].Number; i++)
            {
                int randomPosition = Random.Range(minInclusive: 0, maxExclusive: listFake.Count);
                Transform objectSpawner = this.SpawnObject(position: listFake[randomPosition].position, rotation: listFake[randomPosition].rotation);
                objectSpawner.GetComponentInChildren<GroupSeaDecorObject>().
                    SetObjectSpawner(nameObject: this.resourceSpawners[pointer].NameResourceSpawner);
            }
        }

        protected override void LoadResourceSpawners()
        {
            throw new System.NotImplementedException();
        }

        protected override Transform SpawnObject(Vector3 position, Quaternion rotation) =>
            GroupSeaDecorObjectSpawner.Instance?.SpawnInRegion
                (nameObject: GroupSeaDecorObjectSpawner.pointSpawn_1, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}