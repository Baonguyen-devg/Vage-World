using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseCombatAttack : AutoMonobehaviour
{
    [SerializeField] protected EnemyController controller;
    protected virtual void LoadController() =>
        this.controller = transform.parent?.parent?.GetComponent<EnemyController>();

    [SerializeField] protected Animator animator;
    protected virtual void LoadAnimator() =>
        this.animator = this.controller?.Model?.GetComponent<Animator>();

    [SerializeField] protected Animator animatorSword;
    protected virtual void LoadAnimatorSword() =>
        this.animatorSword = this.controller.transform.Find("Weapon")?.Find("Sword")?.GetComponent<Animator>();

    [SerializeField] protected Transform target;
    protected virtual void LoadTarget() =>
      this.target = GameObject.Find(name: "Player")?.transform;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.LoadAnimator();
        this.LoadAnimatorSword();
        this.LoadTarget();
    }

    protected override void OnEnable()
    {
        this.animatorSword.SetTrigger(name: "SlashLeft");
        StartCoroutine(routine: this.SetRunAnimation());
    }

    protected virtual IEnumerator SetRunAnimation()
    {
        yield return new WaitForSeconds(seconds: 0.5f);
        gameObject.SetActive(value: false);
    }
}
