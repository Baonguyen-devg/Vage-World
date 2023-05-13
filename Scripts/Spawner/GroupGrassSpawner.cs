using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupGrassSpawner : Spawner
{
    protected static GroupGrassSpawner instance;
    public static string pointSpawn_1 = "PointSpawn_1";
    public static GroupGrassSpawner Instance => instance;

    protected override void LoadComponent()
    {
        GroupGrassSpawner.instance = this;
        base.LoadComponent();
    }
}
