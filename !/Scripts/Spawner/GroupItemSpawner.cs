public class GroupItemSpawner : Spawner
{
    protected static GroupItemSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";
    public static GroupItemSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupItemSpawner.instance = this;
    }
}
