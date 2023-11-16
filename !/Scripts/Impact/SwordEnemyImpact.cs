using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSender;

public class SwordEnemyImpact : EnemyImpact
{
    [SerializeField] protected EnemyDamageSender damageSender;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        damageSender = transform.parent?.parent?.Find("DamageSender").GetComponent<EnemyDamageSender>();
    }

    protected override void SendDame(Transform obj) => damageSender.Send(obj);
}
