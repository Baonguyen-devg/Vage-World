using UnityEngine;

public class SeaDecorationSpawner : Spawner
{
    public static readonly string DUCKWEED = "Duckweed";
    public static readonly string STONE_1 = "Stone_1";
    public static readonly string STONE_2 = "Stone_2";
    public static readonly string STONE_3 = "Stone_3";
    public static readonly string SEA_1 = "Sea_1";

    protected static SeaDecorationSpawner instance;
    public static SeaDecorationSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Sea_Decoration";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        SeaDecorationSpawner.instance = this;
    }
}
