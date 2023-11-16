using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSender;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BlueFireBossDemonImpact : AutoMonobehaviour
{
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected BoxCollider2D colli2D;
    [SerializeField] protected EnemyDamageSender damageSender;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        rigid2D ??= GetComponent<Rigidbody2D>();
        colli2D ??= GetComponent<BoxCollider2D>();
        damageSender ??= transform.parent.parent.Find("DamageSender")?.GetComponent<EnemyDamageSender>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => damageSender.Send(obj);
}
