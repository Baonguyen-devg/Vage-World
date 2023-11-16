using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageReceiver;
using Movement;

public class BossDemonController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected BossDemonEnemyDamageReceiver damageReceiver;
    [SerializeField] protected BossDemonEnemyMovement movement;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        model = transform.Find("Model");
        damageReceiver = transform.Find("DamageReceiver").GetComponent<BossDemonEnemyDamageReceiver>();
        movement = transform.Find("Movement").GetComponent<BossDemonEnemyMovement>();
    }

    public Transform Model => model; 
    public BossDemonEnemyDamageReceiver DamageReceiver => damageReceiver;
    public BossDemonEnemyMovement Movement => movement;
}
