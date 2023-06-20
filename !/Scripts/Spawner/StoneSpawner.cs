using UnityEngine;

public class StoneSpawner : Spawner
{
    [SerializeField] protected static StoneSpawner instance;
    public static StoneSpawner Instance => instance;

    protected override void LoadComponent()
    {
        StoneSpawner.instance = this;
        base.LoadComponent();
    }
}
