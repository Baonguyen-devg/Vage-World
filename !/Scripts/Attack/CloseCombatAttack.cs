using UnityEngine;

public class CloseCombatAttack : Attack
{
    [SerializeField] protected Transform target;
 
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }

    protected virtual void LoadTarget() {  /* For override*/  }
}
