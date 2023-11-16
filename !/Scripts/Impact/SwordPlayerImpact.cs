using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlayerImpact : Impact
{
    [SerializeField] protected PlayerController controller;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller ??= GameObject.Find("Player")?.GetComponent<PlayerController>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact") return;
        if (collision.GetComponentInParent<EnemyController>() == null && 
            collision.GetComponentInParent<BossDemonController>() == null) return; 
        controller.DamageSender.Send(collision.transform);
    }
}
