using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    internal class EnemyDamageSender : DamageSender
    {
        protected override void Send(Transform obj) =>
            obj.GetComponentInChildren<PlayerDamageReceiver>()?.DecreaseHealth(this.dame);
    }
}