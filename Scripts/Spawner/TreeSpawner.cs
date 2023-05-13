using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : Spawner
{
    [SerializeField] protected static TreeSpawner instance;
    public static TreeSpawner Instance => instance;

    protected override void LoadComponent()
    {
        TreeSpawner.instance = this;
        base.LoadComponent();
    }
}
