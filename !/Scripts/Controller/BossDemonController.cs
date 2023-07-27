using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageReceiver;
using Movement;

public class BossDemonController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model ??= transform.Find("Model");

    [SerializeField] protected BossDemonEnemyDamageReceiver damageReceiver;
    public BossDemonEnemyDamageReceiver DamageReceiver => this.damageReceiver;
    protected virtual void LoadDamagedReceiver() =>
       this.damageReceiver ??= transform.Find("DamageReceiver")?.GetComponent<BossDemonEnemyDamageReceiver>();

    [SerializeField] protected BossDemonEnemyMovement movement;
    public BossDemonEnemyMovement Movement => this.movement;
    private void LoadMovement() =>
       this.movement ??= transform.Find("Movement")?.GetComponent<BossDemonEnemyMovement>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadMovement();
        this.LoadDamagedReceiver();
    }

}
