using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletImpact : Impact
{
    [SerializeField] protected EnemyBulletController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void LoadController() =>
        this.controller ??= transform.parent.GetComponent<EnemyBulletController>();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") this.SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => this.controller.DamageSender.Send(obj);
}