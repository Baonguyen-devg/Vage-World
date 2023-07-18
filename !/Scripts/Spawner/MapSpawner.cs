using UnityEngine;

public class MapSpawner : Spawner
{
    [SerializeField] protected static MapSpawner instance;
    public static string land_1 = "Land_1";
    public static string sea_1 = "Sea_1";

    public static MapSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        MapSpawner.instance = this;
    }
}
