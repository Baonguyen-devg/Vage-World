using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : Impact
{
    [SerializeField] protected BulletController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
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
        BulletSpawner.Instance.Despawn(transform.parent);
        this.controller.DamagedSender.Send(collision.transform);
    }
}
