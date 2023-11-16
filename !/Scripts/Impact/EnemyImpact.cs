using UnityEngine;

public class EnemyImpact : Impact
{
    [SerializeField] protected EnemyController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller = transform.parent?.parent?.GetComponent<EnemyController>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => controller.DamageSender.Send(obj);
}
