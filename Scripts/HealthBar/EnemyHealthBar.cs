using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : AutoMonobehaviour
{
    [SerializeField] protected EnemyDamagedReceiver damagedReceiver;

    public EnemyDamagedReceiver DamagedReceiver => this.damagedReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagedReceiver();
    }

    protected virtual void LoadDamagedReceiver()
    {
        if (this.damagedReceiver != null) return;
        this.damagedReceiver = transform.parent.parent.GetComponentInChildren<EnemyDamagedReceiver>();
        Debug.Log(transform.name + ": Load Enemy DamagedReceiver", gameObject);
    }

    public virtual void ChangeHealthBar(float percent)
    {
        transform.localScale = new Vector2(percent, 1);
    }
}