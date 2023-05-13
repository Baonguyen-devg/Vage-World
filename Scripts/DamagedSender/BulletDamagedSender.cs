using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamagedSender : DamagedSender
{
    public override void Send(Transform obj)
    {
        base.Send(obj);
        EnemyDamagedReceiver dameToObj = obj.GetComponentInChildren<EnemyDamagedReceiver>();
        if (dameToObj == null) return;

        dameToObj.Deduct(this.dame);
    }
}
