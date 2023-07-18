using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timeDespawn = 2f;
    [SerializeField] protected float timeStartSpawn;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeStartSpawn = 0;
    }

    protected override bool CanDespawn()
    {
        this.timeStartSpawn = this.timeStartSpawn + Time.deltaTime;
        if (this.timeDespawn > timeStartSpawn) return false;
        else return true;
    }
}
