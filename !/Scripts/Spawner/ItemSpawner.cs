using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [SerializeField] protected static ItemSpawner instance;
    public static ItemSpawner Instance => instance;

    public List<Transform> ListPrefab => this.listPrefab;

    protected override void LoadComponent()
    {
        ItemSpawner.instance = this;
        base.LoadComponent();
    }
}
