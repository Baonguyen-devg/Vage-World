public class GroupDecorObjectSpawner : Spawner
{
    protected static GroupDecorObjectSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";

    public static GroupDecorObjectSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(obj: gameObject);
        base.Awake();
    }
}
