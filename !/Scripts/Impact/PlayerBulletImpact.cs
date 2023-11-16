using UnityEngine;

public class PlayerBulletImpact : Impact
{
    [SerializeField] protected PlayerBulletController controller;

    [SerializeField] protected bool haveSkill2;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller ??= transform?.parent?.GetComponent<PlayerBulletController>();
    }

    public virtual void ChangeStatusSkill2(bool status) => haveSkill2 = status;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact" || collision.GetComponentInParent<EnemyController>() == null) return;
        if (transform.parent.name != "Tornado_Bullet") BulletSpawner.Instance.Despawn(transform.parent);
        VFXSpawner.Instance.Spawn("Impact_Bullet_Fire");
        SFXSpawner.Instance.PlaySound("Sound_Impact_Fire");
        controller.DamageSender.Send(collision.transform);
    }
}
