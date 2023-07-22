using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public class PlayerDamageSender : DamageSender
    {
        protected virtual void LoadDamage() =>
            this.dame = (int)this.levelManagerSO?.Dame;

        public override void Send(Transform obj)
        {
            obj.GetComponentInChildren<EnemyDamageReceiver>()?.DecreaseHealth(health: this.dame);
            obj.GetComponent<BossDemonEnemyDamageReceiver>()?.DecreaseHealth(health: this.dame);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.LoadDamage();
        }
    }
}