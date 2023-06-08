using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviours : AutoMonobehaviour
{
    [SerializeField] private List<Transform> listBehaviours;
    [SerializeField] protected EnemyController controller;
    [SerializeField] private double NextAttack, rateTime;
    [SerializeField] protected int count = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.LoadListBehaviours();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected virtual void LoadListBehaviours()
    {
        if (this.listBehaviours.Count != 0) return;
        foreach (Transform behaviour in transform)
            this.listBehaviours.Add(behaviour);
    }

    protected virtual void Update()
    {
        if (Time.time < this.NextAttack) return;
        this.NextAttack = Time.time + this.rateTime;

        this.controller.Model.GetComponent<Animator>().SetTrigger(this.listBehaviours[this.count].name);
        this.count = (this.count + 1) % this.listBehaviours.Count;
    }
}
