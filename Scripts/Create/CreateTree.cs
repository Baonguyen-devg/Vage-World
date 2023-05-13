using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTree : Create
{
    protected override void Start()
    {
        base.Start();
        this.distanceMax = Random.Range(5, 10);
        this.numberGroup = Random.Range(80, 100);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        Transform point = GroupTreeSpawner.Instance.SpawnInRegion(GroupTreeSpawner.pointSpawn_1, this.nameRegion, position, rotation);
        point.GetComponentInChildren<GroupTree>().ChangeMapController(this.mapController);
    }
}
