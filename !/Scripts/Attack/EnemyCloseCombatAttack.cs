using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseCombatAttack : CloseCombatAttack
{
    [SerializeField] protected EnemyController controller;
    protected virtual void LoadController() =>
        this.controller ??= transform.parent.GetComponent<EnemyController>();

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
        this.LoadController();
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
        this.controller.Stand();

        animator.SetTrigger("Attack");
        StartCoroutine(SetRunAnimation());
    }

    protected virtual IEnumerator SetRunAnimation()
    {
        yield return new WaitForSeconds(1);
        this.controller.DoAttack();
    }
}
