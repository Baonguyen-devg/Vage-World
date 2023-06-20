public class GroupEnemySpawner : Spawner
{
    protected static GroupEnemySpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";
    public static GroupEnemySpawner Instance => instance;

    protected override void LoadComponent()
    {
        GroupEnemySpawner.instance = this;
        base.LoadComponent();
    }
}
