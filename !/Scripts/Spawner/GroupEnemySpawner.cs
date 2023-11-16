public class GroupEnemySpawner : Spawner
{
    public static readonly string POINTSPAWN = "PointSpawn_1";

    protected static GroupEnemySpawner instance;
    public static GroupEnemySpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Enemy";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupEnemySpawner.instance = this;
    }
}
