using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlayerImpact : Impact
{
    [SerializeField] protected PlayerController controller;
    protected virtual void LoadController() =>
        this.controller ??= GameObject.Find("Player")?.GetComponent<PlayerController>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact" || collision.GetComponentInParent<EnemyController>() == null) return;
        Debug.LogWarning("Impact");
        this.controller.DamageSender.Send(collision.transform);
    }
}
