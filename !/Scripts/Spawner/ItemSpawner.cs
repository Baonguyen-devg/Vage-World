using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    protected static ItemSpawner instance;
    public static ItemSpawner Instance => instance;

    public List<Transform> Prefabs => this.prefabs;

    protected override string GetPath() => "Prefabs/Prefabs_Item";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        ItemSpawner.instance = this;
    }
}
