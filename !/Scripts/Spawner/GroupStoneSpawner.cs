public class GroupStoneSpawner : Spawner
{
    protected static GroupStoneSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";
    public static GroupStoneSpawner Instance => instance;

    protected override void LoadComponent()
    {
        GroupStoneSpawner.instance = this;
        base.LoadComponent();
    }
}
