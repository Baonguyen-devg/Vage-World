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
        this.LoadAttackDelay();
    }

    protected virtual void LoadAttackDelay() =>
        this.attackDelay = (float)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.AttackDelay;

    protected virtual void LoadPointSpawn() {  /*For Override */  }
}
