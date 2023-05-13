using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatAttack : Attack
{
    [SerializeField] protected EnemyController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected virtual void OnEnable()
    {
        this.CloseAttack();
    }

    protected virtual void CloseAttack()
    {
        this.controller.Model.GetComponent<Animator>().SetBool("Attack", true);
    }
}
