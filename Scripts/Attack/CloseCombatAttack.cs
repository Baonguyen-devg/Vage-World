using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatAttack : Attack
{
    [SerializeField] protected Transform target;

    public void SetTarget(Transform target) { this.target = target; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        //For override
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(transform.parent.position, this.target.position) >= 1) return false; 
        return base.CanAttack();
    }
}
