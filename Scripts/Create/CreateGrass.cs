using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrass : Create
{
    protected override void Start()
    {
        base.Start();
        this.distanceMax = Random.Range(10, 20);
        this.numberGroup = Random.Range(100, 150);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        Transform point = GroupGrassSpawner.Instance.SpawnInRegion(GroupGrassSpawner.pointSpawn_1, this.nameRegion, position, rotation);
        point.GetComponentInChildren<GroupGrass>().ChangeMapController(this.mapController);
    }
}
