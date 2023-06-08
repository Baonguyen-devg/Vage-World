using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatAttack : Attack
{
    [SerializeField] protected EnemyController controller;
    [SerializeField] protected Transform target;

    public void SetTarget(Transform target) { this.target = target; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.target = GameObject.Find("Player").transform;
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(transform.parent.position, this.target.position) >= 1) return false; 
        return base.CanAttack();
    }

    public override void ToAttack()
    {
        base.ToAttack();
        this.controller.Model.GetComponent<BehaviorManager>().GetBehaviorByName("Seismic").gameObject.SetActive(true);
    }
}
