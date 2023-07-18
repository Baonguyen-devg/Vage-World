public class GroupDecorObjectSpawner : Spawner
{
    protected static GroupDecorObjectSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";

    public static GroupDecorObjectSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupDecorObjectSpawner.instance = this;
    }
}
