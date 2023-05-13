using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupTreeSpawner : Spawner
{
    protected static GroupTreeSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";
    public static GroupTreeSpawner Instance => instance;

    protected override void LoadComponent()
    {
        GroupTreeSpawner.instance = this;
        base.LoadComponent();
    }
}
