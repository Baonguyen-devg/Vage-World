using System.Collections.Generic;
using UnityEngine;
using Group;

namespace CreatingPackage
{
    public class CreateDecorObject : Create
    {
        protected override void LoadResourceSpawners()
        {
            this.resourceSpawners.Clear();
            foreach (var decorSO in this.levelManagerSO.DecorObjects)
                if (!decorSO.Name.Equals("This is a null element"))
                    this.resourceSpawners.Add(new ResourceSpawner(decorSO.Name, decorSO.NumberGroup));
        }

        protected override void Group(int pointer)
        {
            List<Transform> listFake = this.mapController.CreateMap.landList;
            if (listFake.Count == 0) return;

            for (int i = 1; i <= this.resourceSpawners[pointer].Number; i++)
            {
                int randomPosition = Random.Range(minInclusive: 0, maxExclusive: listFake.Count);
                Transform objectSpawner = this.SpawnObject(position: listFake[randomPosition].position, rotation: listFake[randomPosition].rotation);
                objectSpawner.GetComponentInChildren<GroupDecorObject>().
                    SetObjectSpawner(nameObject: this.resourceSpawners[pointer].NameResourceSpawner);
            }
        }

        protected override Transform SpawnObject(Vector3 position, Quaternion rotation) =>
            GroupDecorObjectSpawner.Instance?.SpawnInRegion
                (nameObject: GroupDecorObjectSpawner.pointSpawn_1, nameRegion: "Forest", postion: position, rotation: rotation);
    }
}