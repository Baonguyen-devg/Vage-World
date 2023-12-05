using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSender;

public class SwordEnemyImpact : EnemyImpact
{
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        damageSender = transform.parent?.parent?.Find("DamageSender").GetComponent<EnemyDamageSender>();
    }
}
