using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : AutoMonobehaviour
{
    [SerializeField] protected float speedAttack;
    [SerializeField] protected float rateTimeAttack;
    [SerializeField] protected bool skill1, skill2, skill3;
    protected float nextTimeAttack;

    protected virtual void FixedUpdate()
    {
        if (this.CanAttack()) this.ToAttack();
    }

    protected virtual void ToAttack()
    {
        //For Override
    }

    protected virtual bool CanAttack()
    {
        if (Time.time < this.nextTimeAttack) return false;

        this.nextTimeAttack = Time.time + this.rateTimeAttack;
        return true;
    }
}
