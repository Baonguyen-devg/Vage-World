using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSender;

public class SwordEnemyImpact : EnemyImpact
{
    [SerializeField] protected EnemyDamageSender damageSender;
    protected virtual void LoadDamageSender() =>
        this.damageSender = transform.parent?.parent?.Find("DamageSender").GetComponent<EnemyDamageSender>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
    }

    protected override void SendDame(Transform obj) => this.damageSender.Send(obj);
}
