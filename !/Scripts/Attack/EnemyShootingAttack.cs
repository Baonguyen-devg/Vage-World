using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAttack : ShootingAttack
{
    [SerializeField] protected Transform target;
    protected virtual void LoadTarget() =>
        this.target = (this.target == null) ? GameObject.Find("Player").transform : this.target;

    [SerializeField] protected EnemyController controller;
    protected virtual void LoadController() =>
        this.controller ??= transform.parent.GetComponent<EnemyController>();
 
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.LoadTarget();
        this.LoadPointSpawn();
    }

    protected virtual void LoadPointSpawn() {  /*For Override */  }
}
