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

    protected override void LoadTarget() =>
        this.target ??= GameObject.Find("Player").transform;

    protected virtual void LoadController() =>
        this.controller ??= transform.parent.GetComponent<EnemyController>();

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
