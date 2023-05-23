using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : Impact
{
    [SerializeField] protected BulletController controller;
    [SerializeField] protected bool haveSkill2;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    public virtual void ChangeStatusSkill2(bool status)
    {
        this.haveSkill2 = status;
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact") return;
        if (collision.GetComponentInParent<EnemyController>() == null) return;
        if (transform.parent.name != "Tornado_Bullet") BulletSpawner.Instance.Despawn(transform.parent);
        this.controller.DamagedSender.Send(collision.transform);
        if (this.haveSkill2 == true) this.MakingStop(collision.transform);
    }

    protected virtual void MakingStop(Transform objectImpact)
    {
        EnemyController controller = objectImpact.parent.GetComponent<EnemyController>();
        controller.DamagedReceiver.StopMoving(2);
    }
}
