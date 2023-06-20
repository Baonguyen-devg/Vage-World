using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DamageReceiver
{
    internal class BossEnemyDamageReceiver : EnemyDamageReceiver
    {
        protected override void OnDead()
        {
            base.OnDead();
            if (transform.parent.name == "Boss") UIController.Instance.WinGame();
        }
    }
}