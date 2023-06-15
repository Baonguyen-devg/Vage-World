using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : BulletController
{
    [SerializeField] protected EnemyDamagedSender EnemyDamagedSender;

    protected override void LoadDamagedSender()
    {
        if (this.EnemyDamagedSender != null) return;
        this.EnemyDamagedSender = transform.Find("DamagedSender").GetComponent<EnemyDamagedSender>();
        Debug.Log(transform.name + ": Load DamagedSender", gameObject);
    }
}
