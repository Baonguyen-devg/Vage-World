using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAttack : ShootingAttack
{
    [SerializeField] protected EnemyController controller;
    [SerializeField] protected List<Transform> pointSpawns;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.LoadTarget(); 
        this.LoadPointSpawn();
    }

    protected override void LoadTarget()
    {
        base.LoadTarget();
        this.target = GameObject.Find("Player").transform;
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected virtual void LoadPointSpawn()
    {
        if (this.pointSpawns.Count != 0) return;
        foreach (Transform pointSpawn in transform)
            this.pointSpawns.Add(pointSpawn);
    }

    public override void ToAttack()
    {
        base.ToAttack();
        string bullet = transform.parent.name + "_Bullet";
        foreach (Transform point in this.pointSpawns)
            this.Shoote(bullet, point);
    }
}
