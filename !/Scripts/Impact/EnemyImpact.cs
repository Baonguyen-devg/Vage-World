using UnityEngine;

public class EnemyImpact : Impact
{
    [SerializeField] protected DamageSender.EnemyDamageSender damageSender;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => damageSender.Send(obj);
}
