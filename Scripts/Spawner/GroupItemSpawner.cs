using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupItemSpawner : Spawner
{
    protected static GroupItemSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";
    public static GroupItemSpawner Instance => instance;

    protected override void LoadComponent()
    {
        GroupItemSpawner.instance = this;
        base.LoadComponent();
    }
}
