using UnityEngine;

public class EnemyImpact : Impact
{
    [SerializeField] protected EnemyController controller;
    protected virtual void LoadController() =>
        this.controller ??= transform.parent.parent.parent.GetComponent<EnemyController>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") this.SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => this.controller.DamageSender.Send(obj);
}
