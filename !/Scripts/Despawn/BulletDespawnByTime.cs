using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnByTime : DespawnByTime
{
    public override void DespawnObject()
    {
        base.DespawnObject();
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
