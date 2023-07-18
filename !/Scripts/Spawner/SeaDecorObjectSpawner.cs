using UnityEngine;

public class SeaDecorObjectSpawner : Spawner
{
    [SerializeField] protected static SeaDecorObjectSpawner instance;
    public static SeaDecorObjectSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        SeaDecorObjectSpawner.instance = this;
    }
}
