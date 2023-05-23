using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : Create
{
    protected override void Awake()
    {
        base.Awake();
        this.distanceMax = Random.Range(10, 20);
        this.numberGroup = Random.Range(100, 150);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        Transform point = GroupItemSpawner.Instance.SpawnInRegion(GroupItemSpawner.pointSpawn_1, this.nameRegion, position, rotation);
        point.GetComponentInChildren<GroupItem>().ChangeMapController(this.mapController);
    }
}
