using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDecorObject : Create
{
    protected override void Awake()
    {
        base.Start();
        this.distanceMax = Random.Range(5, 10);
        this.numberGroup = 200;
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        if (GroupDecorObjectSpawner.Instance == null) Debug.LogError("Warning");
        Transform point = GroupDecorObjectSpawner.Instance.SpawnInRegion(GroupDecorObjectSpawner.pointSpawn_1, this.nameRegion, position, rotation);
        point.GetComponentInChildren<GroupDecorObject>().ChangeMapController(this.mapController);
    }
}
