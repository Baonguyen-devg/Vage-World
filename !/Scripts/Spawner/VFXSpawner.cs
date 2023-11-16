using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : Spawner
{
    public static readonly string IMPACT_SWORD = "Impact_Sword";
    public static readonly string PICK_ITEM = "Number_Pick_Item";

    protected static VFXSpawner instance;
    public static VFXSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_VFX";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        VFXSpawner.instance = this;
    }
}
