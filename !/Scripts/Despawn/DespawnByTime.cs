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
        timeStartSpawn = 0;
    }

    protected override bool CanDespawn()
    {
        timeStartSpawn = timeStartSpawn + Time.deltaTime;
        if (timeDespawn > timeStartSpawn) return false;
        else return true;
    }
}
