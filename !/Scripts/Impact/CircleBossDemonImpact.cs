using DamageSender;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class CircleBossDemonImpact : AutoMonobehaviour
{
    [SerializeField] protected Rigidbody2D rigid2D;
    protected virtual void LoadRigidbody2D() =>
        this.rigid2D ??= GetComponent<Rigidbody2D>();

    [SerializeField] protected CircleCollider2D colli2D;
    protected virtual void LoadCircleCollider2D() =>
        this.colli2D ??= GetComponent<CircleCollider2D>();

    [SerializeField] protected EnemyDamageSender damageSender;
    protected virtual void LoadDamagedSender() =>
        this.damageSender ??= transform.parent.Find("DamageSender")?.GetComponent<EnemyDamageSender>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCircleCollider2D();
        this.LoadRigidbody2D();
        this.LoadDamagedSender();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") 
            this.SendDame(obj: collision.transform);
    }

    protected virtual void SendDame(Transform obj) => this.damageSender.Send(obj);
}
