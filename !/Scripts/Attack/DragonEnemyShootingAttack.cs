using System.Collections.Generic;
using UnityEngine;

public class DragonEnemyShootingAttack : EnemyShootingAttack
{
    [SerializeField] protected List<Transform> pointSpawns;
    protected override void LoadPointSpawn()
    {
        if (this.pointSpawns.Count != 0) return;
        foreach (Transform pointSpawn in transform)
            this.pointSpawns.Add(item: pointSpawn);
    }

    [SerializeField] protected float distanceCanShoote = 6f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawn();
        this.LoadDistanceCanShoote();
    }

    protected virtual void LoadDistanceCanShoote() =>
        this.distanceCanShoote = (float)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.DistanceAttack;

    public override void ToAttack()
    {
        base.ToAttack();
        this.controller.Model.GetComponent<Animator>().SetTrigger(name: "Attack");

        string bullet = transform.parent.name + "_Bullet";
        foreach (Transform point in this.pointSpawns)
            this.Shoote(nameBullet: bullet, posShoote: point);
    }

    protected override bool CanAttack()
    {
        if (this.target == null) return false;
        if (Vector2.Distance(a: transform.parent.position, b: this.target.position) >= this.distanceCanShoote) return false;
        return base.CanAttack();
    }
}
