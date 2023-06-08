using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupDecorObjectSpawner : Spawner
{
    protected static GroupDecorObjectSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";

    public static GroupDecorObjectSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        base.Awake();
    }
}
