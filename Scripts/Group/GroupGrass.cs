using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupGrass : Group
{
    [SerializeField] protected GroupSO grassSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGrassSO();
    }

    protected virtual void LoadGrassSO()
    {
        if (this.grassSO != null) return;
        string resPath = "Group/" + transform.name;
        this.grassSO = Resources.Load<GroupSO>(resPath);
        this.maxNumber = this.grassSO.MaxOSNumber;
        this.minNumber = this.grassSO.MinOSNumber;
        Debug.LogWarning(transform.name + ": Load GroupGrassSO" + resPath, gameObject);
    }


    public override void ChangeMapController(MapController map)
    {
        this.objectSpawner = GrassSpawner.Instance.GetRandomPrefab();
        base.ChangeMapController(map);
    }
 
    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        GrassSpawner.Instance.SpawnInRegion(this.objectSpawner, this.nameRegion, position, rotation);
    }
}
