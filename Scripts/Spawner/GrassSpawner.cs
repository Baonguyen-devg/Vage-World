using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : Spawner
{ 
    [SerializeField] protected static GrassSpawner instance;
    public static GrassSpawner Instance => instance;

    protected override void LoadComponent()
    {
        GrassSpawner.instance = this;
        base.LoadComponent();
    }
}
