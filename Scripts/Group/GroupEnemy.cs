using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemy : Group
{
    [SerializeField] protected GroupSO EnemySO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
    }

    protected virtual void LoadEnemySO()
    {
        if (this.EnemySO != null) return;
        string resPath = "Group/" + transform.name;
        this.EnemySO = Resources.Load<GroupSO>(resPath);
        this.maxNumber = this.EnemySO.MaxOSNumber;
        this.minNumber = this.EnemySO.MinOSNumber;
        Debug.LogWarning(transform.name + ": Load EnemyStoneSO" + resPath, gameObject);
    }

    public override void ChangeMapController(MapController map)
    {
        this.objectSpawner = EnemySpawner.Instance.GetRandomPrefab();
        base.ChangeMapController(map);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        Transform enemy = EnemySpawner.Instance.SpawnInRegion(this.objectSpawner, this.nameRegion, position, rotation);
        transform.parent.GetComponent<PointSpawnEnemy>().Add(enemy);
    }

}
