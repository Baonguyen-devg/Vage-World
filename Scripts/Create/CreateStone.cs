using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStone : Create
{
    protected override void Start()
    {
        base.Start();
        this.distanceMax = Random.Range(10, 20);
        this.numberGroup = Random.Range(50, 80);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        Transform point = GroupStoneSpawner.Instance.SpawnInRegion(GroupStoneSpawner.pointSpawn_1, this.nameRegion, position, rotation);
        point.GetComponentInChildren<GroupStone>().ChangeMapController(this.mapController);
    }
}
