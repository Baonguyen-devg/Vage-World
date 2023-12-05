using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlayerImpact : Impact
{
    [SerializeField] protected PlayerController controller;
    [SerializeField] protected float timeDelay = 1f;

    private float countDown;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller ??= GameObject.Find("Player")?.GetComponent<PlayerController>();
    }
    #endregion

    protected void Update()
    {
        if (countDown <= 0) return;
        countDown = countDown - Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Impact" || countDown > 0) return;
        if (collision.GetComponent<DamageReceiver.EnemyDamageReceiver>() == null) return; 
        controller.DamageSender.Send(collision.transform);
        countDown = timeDelay;
    }
}
