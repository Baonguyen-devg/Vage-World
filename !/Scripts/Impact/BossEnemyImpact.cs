using UnityEngine;

public class BossEnemyImpact : Impact
{
   /* [SerializeField] protected BossDemonController controller;
    protected virtual void LoadBossDemonController() =>
        this.controller ??= transform.parent.parent.GetComponent<BossDemonController>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossDemonController();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") this.SendDame(collision.transform);
    }

    protected virtual void SendDame(Transform obj) => this.controller.DamageSender.Send(obj);*/
}
