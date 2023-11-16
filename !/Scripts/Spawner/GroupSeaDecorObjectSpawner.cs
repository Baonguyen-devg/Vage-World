public class GroupSeaDecorObjectSpawner : Spawner
{
    public static readonly string POINTSPAWN = "PointSpawn_1";

    protected static GroupSeaDecorObjectSpawner instance;
    public static GroupSeaDecorObjectSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_land_Decoration";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GroupSeaDecorObjectSpawner.instance = this;
    }
}
