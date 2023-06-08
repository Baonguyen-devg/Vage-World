using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyImpact : EnemyImpact
{
    protected override void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.parent.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }
}
