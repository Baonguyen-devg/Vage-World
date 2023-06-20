using UnityEngine;

public abstract class Attack : AutoMonobehaviour
{
    [SerializeField] protected float attackDelay;
    [SerializeField] protected bool skill1, skill2, skill3;
    [SerializeField] protected float attackTimer;

    protected virtual void Update()
    {
        if (this.CanAttack()) this.ToAttack();
    }

    public virtual void ToAttack()
    {

    }

    protected virtual bool CanAttack()
    {
        this.attackTimer = this.attackTimer + Time.deltaTime;
        if (this.attackTimer < this.attackDelay) return false;
        return true;
    }
}
