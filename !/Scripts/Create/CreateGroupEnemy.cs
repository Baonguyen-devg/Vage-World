using UnityEngine;

public class CreateGroupEnemy : Create
{
    protected override void Start()
    {
        base.Start();
        this.distanceMax = Random.Range(10, 20);
        this.numberGroup = Random.Range(10, 20);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        Transform point = GroupEnemySpawner.Instance.SpawnInRegion(GroupEnemySpawner.pointSpawn_1, this.nameRegion, position, rotation);
        point.GetComponentInChildren<GroupEnemy>().ChangeMapController(this.mapController);
    }
}
