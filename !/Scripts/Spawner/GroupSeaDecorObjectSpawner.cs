public class GroupSeaDecorObjectSpawner : Spawner
{
    protected static GroupSeaDecorObjectSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";

    public static GroupSeaDecorObjectSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupSeaDecorObjectSpawner.instance = this;
    }
}
