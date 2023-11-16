public class GroupItemSpawner : Spawner
{
    public static readonly string POINTSPAWN = "PointSpawn_1";

    protected static GroupItemSpawner instance;
    public static GroupItemSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Group_Item";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupItemSpawner.instance = this;
    }
}
