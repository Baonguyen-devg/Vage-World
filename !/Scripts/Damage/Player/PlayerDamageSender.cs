using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public class PlayerDamageSender : DamageSender
    {
        public override void Send(Transform obj) =>
         obj.GetComponentInChildren<EnemyDamageReceiver>()?.DecreaseHealth(this.dame);
    }
}