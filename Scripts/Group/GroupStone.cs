using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupStone : Group
{
    [SerializeField] protected GroupSO stoneSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStoneSO();
    }

    protected virtual void LoadStoneSO()
    {
        if (this.stoneSO != null) return;
        string resPath = "Group/" + transform.name;
        this.stoneSO = Resources.Load<GroupSO>(resPath);
        this.maxNumber = this.stoneSO.MaxOSNumber;
        this.minNumber = this.stoneSO.MinOSNumber;
        Debug.LogWarning(transform.name + ": Load GroupStoneSO" + resPath, gameObject);
    }

    public override void ChangeMapController(MapController map)
    {
        this.objectSpawner = StoneSpawner.Instance.GetRandomPrefab();
        base.ChangeMapController(map);
    }
    
    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        StoneSpawner.Instance.SpawnInRegion(this.objectSpawner, this.nameRegion, position, rotation);
    }
}
