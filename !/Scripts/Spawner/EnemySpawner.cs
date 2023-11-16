public class EnemySpawner : Spawner
{
    public static readonly string ENEMY_ONE = "Enemy_1";
    public static readonly string ENEMY_TWO = "Enemy_2";

    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Enemy";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        EnemySpawner.instance = this;
    }
}
