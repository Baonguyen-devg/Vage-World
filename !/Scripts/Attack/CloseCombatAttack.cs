using UnityEngine;

public class CloseCombatAttack : Attack
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distanceToCloseCombat = 1f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }

    protected virtual void LoadTarget() {  /* For override*/  }
}
