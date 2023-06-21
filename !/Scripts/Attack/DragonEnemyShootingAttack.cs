using System.Collections.Generic;
using UnityEngine;

public class DragonEnemyShootingAttack : EnemyShootingAttack
{
    [SerializeField] protected List<Transform> pointSpawns;
    [SerializeField] protected float distanceCanShoote = 6f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawn();
    }

    protected override void LoadPointSpawn()
    {
        if (this.pointSpawns.Count != 0) return;
        foreach (Transform pointSpawn in transform)
            this.pointSpawns.Add(pointSpawn);
    }

    public override void ToAttack()
    {
        base.ToAttack();
        this.controller.Model.GetComponent<Animator>().SetTrigger("Attack");

        string bullet = transform.parent.name + "_Bullet";
        foreach (Transform point in this.pointSpawns)
            this.Shoote(bullet, point);
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(transform.parent.position, this.target.position) >= this.distanceCanShoote) return false;
        return base.CanAttack();
    }
}
