using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooteBlueFlame : AutoMonobehaviour
{
    [SerializeField] protected BossDemonController controller;
    protected virtual void LoadController() =>
        this.controller = transform.parent?.parent?.GetComponent<BossDemonController>();

    [SerializeField] protected Animator animatorBoss;
    protected virtual void LoadAnimator() =>
        this.animatorBoss = transform.parent?.parent?.Find("Model")?.GetComponent<Animator>();

    [SerializeField] protected Transform target;
    protected virtual void LoadTarget() =>
        this.target = GameObject.Find("Player")?.transform;

    [SerializeField] protected Vector3 distanceToTarget;

    protected override void LoadComponent()
    {
        this.LoadAnimator();
        this.LoadController();
        this.LoadTarget();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.animatorBoss.SetTrigger("Disappear");
        this.controller.Movement.gameObject.SetActive(false);
        StartCoroutine(this.Accumulation());
        StartCoroutine(this.DisActive());
    }

    protected virtual Vector3 TeleportPosition() =>
         this.target.position + this.distanceToTarget;

    protected virtual IEnumerator Accumulation()
    {
        yield return new WaitForSeconds(1f);
        this.controller.gameObject.transform.position = this.TeleportPosition();
        this.animatorBoss.SetTrigger("Appear");
        StartCoroutine(this.Attack());
    }

    protected virtual IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        SFXSpawner.Instance.PlaySound("Sound_Fire_Explosion");
        this.animatorBoss.SetTrigger("Attack");
    }

    protected virtual IEnumerator DisActive()
    {
        yield return new WaitForSeconds(3.1f);
        this.controller.Movement.gameObject.SetActive(true);
        this.animatorBoss.SetTrigger("Idle");
        gameObject.SetActive(false);
    }
}
