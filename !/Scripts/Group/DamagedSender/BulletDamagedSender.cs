using UnityEngine;

public class BulletDamagedSender : DamagedSender
{
    public virtual void IncreaseDame(int dame)
    {
        this.dame = this.dame + dame;
    }

    public override void Send(Transform obj)
    {
        base.Send(obj);
        EnemyDamagedReceiver dameToObj = obj.GetComponentInChildren<EnemyDamagedReceiver>();
        if (dameToObj == null) return;

        dameToObj.Deduct(this.dame);
    }
}
