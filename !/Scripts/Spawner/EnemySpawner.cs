public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static string enemy_1 = "Enemy_1";
    public static string enemy_2 = "Enemy_2";

    public static EnemySpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        EnemySpawner.instance = this;
    }
}
