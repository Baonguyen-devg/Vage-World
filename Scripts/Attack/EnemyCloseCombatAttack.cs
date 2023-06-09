using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseCombatAttack : CloseCombatAttack
{
    [SerializeField] protected EnemyController controller;
    [SerializeField] protected string nameBehavioirCloseCombat;

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

    protected override void LoadTarget()
    {
        base.LoadTarget();
        this.target = GameObject.Find("Player").transform;
    }

    public override void ToAttack()
    {
        base.ToAttack();
        this.controller.Model.GetComponent<BehaviorManager>().GetBehaviorByName(this.nameBehavioirCloseCombat).gameObject.SetActive(true);
    }
}
