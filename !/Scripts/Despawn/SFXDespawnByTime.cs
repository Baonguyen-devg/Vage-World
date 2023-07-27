using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXDespawnByTime : DespawnByTime
{
    public override void DespawnObject()
    {
        base.DespawnObject();
        SFXSpawner.Instance.Despawn(transform.parent);
    }
}
