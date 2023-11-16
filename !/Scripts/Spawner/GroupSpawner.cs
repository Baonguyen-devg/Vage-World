public class GroupSpawner : Spawner
{
    public static readonly string LAND_DECORATION = "Group Land Decoration";
    public static readonly string SEA_DECORATION = "Group Sea Decoration";
    public static readonly string ITEM = "Group Item";
    public static readonly string ENEMY = "Group Enemy";

    protected static GroupSpawner instance;
    public static GroupSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Group";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupSpawner.instance = this;
    }
}
