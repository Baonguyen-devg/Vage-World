using UnityEngine;

public class EnemyCloseCombatAttack : CloseCombatAttack
{
    [SerializeField] protected BehaviorManager behaviourManager;
    protected virtual void LoadBehaviourManager() =>
        this.behaviourManager ??= transform?.parent?.GetComponent<EnemyController>()?.Model?.GetComponent<BehaviorManager>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBehaviourManager();
    }

    protected override void LoadTarget() => 
        this.target = GameObject.Find(name: "Player").transform;

    public override void ToAttack()
    {
        base.ToAttack();
        this.attackTimer = 0;
        transform.parent.GetComponent<EnemyController>().Model.GetComponent<Animator>().SetTrigger("Attack");
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(a: transform.parent.position, b: this.target.position) >= this.distanceToCloseCombat) return false;
        return base.CanAttack();
    }
}
