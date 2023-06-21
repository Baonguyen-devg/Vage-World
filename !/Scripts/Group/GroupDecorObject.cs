using UnityEngine;

public class GroupDecorObject : Group
{
    [SerializeField] protected GroupSO decorObejctSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDecorObjectSO();
    }

    protected virtual void LoadDecorObjectSO()
    {
        if (this.decorObejctSO != null) return;
        string resPath = "Group/" + transform.name;
        this.decorObejctSO = Resources.Load<GroupSO>(resPath);
        this.maxNumber = this.decorObejctSO.MaxOSNumber;
        this.minNumber = this.decorObejctSO.MinOSNumber;
        Debug.LogWarning(transform.name + ": Load GroupDecorObjectSO" + resPath, gameObject);
    }

    public override void ChangeMapController(MapController map)
    {
        this.objectSpawner = DecorObjectSpawner.Instance.GetRandomPrefab();
        base.ChangeMapController(map);
    }

    protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
        DecorObjectSpawner.Instance.SpawnInRegion(this.objectSpawner, this.nameRegion, position, rotation);
}
