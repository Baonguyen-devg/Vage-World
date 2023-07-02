using UnityEngine;

public class SeaDecorObjectSpawner : Spawner
{
    [SerializeField] protected static SeaDecorObjectSpawner instance;
    public static SeaDecorObjectSpawner Instance => instance;

    protected override void Awake() => SeaDecorObjectSpawner.instance = this;
}
