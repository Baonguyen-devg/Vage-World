using UnityEngine;

public class PlayerBulletImpact : Impact
{
    [SerializeField] protected PlayerBulletController controller;
    [SerializeField] protected bool haveSkill2;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    public virtual void ChangeStatusSkill2(bool status) => this.haveSkill2 = status;

    protected virtual void LoadController() =>
        this.controller = (this.controller != null) ? this.controller
            : transform.parent.GetComponent<PlayerBulletController>();


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact" || collision.GetComponentInParent<EnemyController>() == null) return;
        if (transform.parent.name != "Tornado_Bullet") BulletSpawner.Instance.Despawn(transform.parent);
        this.controller.DamageSender.Send(collision.transform);
    }
}
