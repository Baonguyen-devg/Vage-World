using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSmokeDieEnemyDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        base.DespawnObject();
        VFXSpawner.Instance.Despawn(transform.parent);
    }
}
