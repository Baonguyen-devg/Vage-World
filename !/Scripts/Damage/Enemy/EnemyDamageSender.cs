using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public class EnemyDamageSender : DamageSender
    {
        protected virtual void LoadDamage() =>
            this.dame = (int)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.Dame;

        public override void Send(Transform obj) =>
            obj.GetComponentInChildren<PlayerDamageReceiver>()?.DecreaseHealth(health: this.dame);

        protected override void OnEnable()
        {
            base.OnEnable();
            this.LoadDamage();
        }
    }
}