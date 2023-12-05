using UnityEngine;

public class LandDecorationSpawner : Spawner
{
    public static readonly string LAND_1 = "Land_1";
    public static readonly string COIN = "Coin";

    protected static LandDecorationSpawner instance;
    public static LandDecorationSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Land_Decoration";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        LandDecorationSpawner.instance = this;
    }
}
