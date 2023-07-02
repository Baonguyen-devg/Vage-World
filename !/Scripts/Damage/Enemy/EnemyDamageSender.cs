using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public class EnemyDamageSender : DamageSender
    {
        public override void Send(Transform obj) =>
            obj.GetComponentInChildren<PlayerDamageReceiver>()?.DecreaseHealth(health: this.dame);
    }
}