using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupTree : Group
{
    [SerializeField] protected GroupSO treeSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTreeSO();
    }

    protected virtual void LoadTreeSO()
    {
        if (this.treeSO != null) return;
        string resPath = "Group/" + transform.name;
        this.treeSO = Resources.Load<GroupSO>(resPath);
        this.maxNumber = this.treeSO.MaxOSNumber;
        this.minNumber = this.treeSO.MinOSNumber;
        Debug.LogWarning(transform.name + ": Load GroupTreeSO" + resPath, gameObject);
    }

    public override void ChangeMapController(MapController map)
    {
        this.objectSpawner = TreeSpawner.Instance.GetRandomPrefab();
        base.ChangeMapController(map);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        int key = Random.Range(3, 5);
        Transform tree = TreeSpawner.Instance.SpawnInRegion(this.objectSpawner, this.nameRegion, position, rotation);
        tree.GetComponent<TreeController>().Model.localScale = new Vector3(key, key, 1);
    }
}
