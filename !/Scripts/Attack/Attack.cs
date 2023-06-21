using UnityEngine;

public abstract class Attack : AutoMonobehaviour
{
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float attackTimer;

    protected virtual void Update()
    {
        if (this.CanAttack()) this.ToAttack();
    }

    public virtual void ToAttack() {   /*For Override */  }

    protected virtual bool CanAttack()
    {
        this.attackTimer = this.attackTimer + Time.deltaTime;
        if (this.attackTimer < this.attackDelay) return false;
        return true;
    }
}
