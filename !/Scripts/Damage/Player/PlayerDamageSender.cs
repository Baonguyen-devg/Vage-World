using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    internal class PlayerDamageSender : DamageSender
    {
        protected override void Send(Transform obj) =>
         obj.GetComponentInChildren<EnemyDamageReceiver>()?.DecreaseHealth(this.dame);
    }
}