using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public class EnemyDamageSender : DamageSender
    {
        public override void Send(Transform obj) =>
            obj.GetComponentInChildren<PlayerDamageReceiver>()?.DecreaseHealth(health: dame);

        protected override void OnEnable()
        {
            base.OnEnable();
           // dame = (int)levelManagerSO?.GetEnemySOByName(transform.parent.name)?.Dame;
        }
    }
}