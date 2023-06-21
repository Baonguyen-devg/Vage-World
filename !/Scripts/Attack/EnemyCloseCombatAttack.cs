using UnityEngine;

public class EnemyCloseCombatAttack : CloseCombatAttack
{
    [SerializeField] protected BehaviorManager behaviourManager;
    [SerializeField] protected string nameBehaviour;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBehaviourManager();
    }

    protected virtual void LoadBehaviourManager() =>
        this.behaviourManager = (this.behaviourManager != null) ? this.behaviourManager
            : transform.parent.GetComponent<EnemyController>().Model.GetComponent<BehaviorManager>();

    protected override void LoadTarget() => this.target = GameObject.Find("Player").transform;

    public override void ToAttack()
    {
        base.ToAttack();
        this.attackTimer = 0;
        this.behaviourManager.GetBehaviorByName(this.nameBehaviour).gameObject.SetActive(true);
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(transform.parent.position, this.target.position) >= this.distanceToCloseCombat) return false;
        return base.CanAttack();
    }
}
