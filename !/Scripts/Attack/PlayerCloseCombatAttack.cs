using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseCombatAttack : CloseCombatAttack
{
    [SerializeField] protected Animator animator;
    protected virtual void LoadAnimator() =>
        this.animator = transform.Find("Sword")?.GetComponent<Animator>();

    [SerializeField] protected Transform sword;
    protected virtual void LoadSword() =>
        this.sword = transform.Find("Sword");

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSword();
        this.LoadAnimator();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadAttackDelay();
    }

    protected virtual void LoadAttackDelay() =>
        this.attackDelay = (float)this.levelManagerSO?.AttackDelay;

    public override void ToAttack()
    {
        base.ToAttack();
        if (!Input.GetMouseButtonDown(0)) return;

        this.attackTimer = 0;
        this.animator.SetTrigger("SlashLeft");
        StartCoroutine(ResetRotation());
    }

    protected virtual IEnumerator ResetRotation()
    {
        yield return new WaitForSeconds(0.4f);
        this.animator.SetTrigger("Entry");
    }
}
