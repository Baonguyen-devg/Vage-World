using UnityEngine;

public class EnemyDamagedSender : DamagedSender
{
    public override void Send(Transform obj)
    {
        base.Send(obj);
        PlayerDamagedReceiver dameToObj = obj.GetComponentInChildren<PlayerDamagedReceiver>();
        if (dameToObj == null) return;

        dameToObj.Deduct(this.dame);
    }
}
