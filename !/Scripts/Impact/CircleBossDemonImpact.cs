using DamageSender;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class CircleBossDemonImpact : AutoMonobehaviour
{
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected CircleCollider2D colli2D;
    [SerializeField] protected EnemyDamageSender damageSender;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        rigid2D ??= GetComponent<Rigidbody2D>();
        colli2D ??= GetComponent<CircleCollider2D>();
        damageSender ??= transform.parent.Find("DamageSender")?.GetComponent<EnemyDamageSender>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") 
            SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => damageSender.Send(obj);
}
