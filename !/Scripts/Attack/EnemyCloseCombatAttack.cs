using UnityEngine;

public class EnemyCloseCombatAttack : CloseCombatAttack
{
    [SerializeField] protected BehaviorManager behaviourManager;
    protected virtual void LoadBehaviourManager() =>
        this.behaviourManager ??= transform?.parent?.GetComponent<EnemyController>()?.Model?.GetComponent<BehaviorManager>();

    [SerializeField] protected Animator animator;
    protected virtual void LoadAnimator() =>
        this.animator = transform.parent.GetComponent<EnemyController>().Model.GetComponent<Animator>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBehaviourManager();
        this.LoadAnimator();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadAttackDelay();
    }

    protected override void LoadTarget() => 
        this.target = GameObject.Find(name: "Player").transform;

    protected virtual void LoadAttackDelay() =>
        this.attackDelay = (float)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.AttackDelay;

    public override void ToAttack()
    {
        base.ToAttack();
        this.attackTimer = 0;
        animator.SetTrigger("Attack");
        Invoke("SetRunAnimation", 1f);
        
    }

    private void SetRunAnimation() => this.animator.SetTrigger("Run");
}
