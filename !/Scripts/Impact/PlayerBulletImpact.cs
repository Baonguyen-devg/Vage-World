using UnityEngine;

public class PlayerBulletImpact : Impact
{
    [SerializeField] protected PlayerBulletController controller;
    protected virtual void LoadController() =>
        this.controller ??= transform?.parent?.GetComponent<PlayerBulletController>();

    [SerializeField] protected bool haveSkill2;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    public virtual void ChangeStatusSkill2(bool status) => this.haveSkill2 = status;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact" || collision.GetComponentInParent<EnemyController>() == null) return;
        if (transform.parent.name != "Tornado_Bullet") BulletSpawner.Instance.Despawn(transform.parent);
        VFXSpawner.Instance.SpawnInRegion("Impact_Bullet_Fire", "Forest", collision.transform.position, collision.transform.rotation);
        SFXSpawner.Instance.PlaySound("Sound_Impact_Fire", "Forest");
        this.controller.DamageSender.Send(collision.transform);
    }
}
