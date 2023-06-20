using UnityEngine;

public class DecorObjectSpawner : Spawner
{
    [SerializeField] protected static DecorObjectSpawner instance;
    public static DecorObjectSpawner Instance => instance;

    protected override void Awake()
    {
        DecorObjectSpawner.instance = this;
    }
}
