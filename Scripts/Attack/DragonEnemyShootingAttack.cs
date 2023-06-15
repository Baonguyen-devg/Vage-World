using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemyShootingAttack : EnemyShootingAttack
{
    public override void ToAttack()
    {
        base.ToAttack();
        this.controller.Model.GetComponent<Animator>().SetTrigger("Attack");
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(transform.parent.position, this.target.position) >= 6) return false;
        return base.CanAttack();
    }
}
