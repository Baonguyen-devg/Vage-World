using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class EnemyShootingAttack : ShootingAttack
    {
        [SerializeField] protected Transform target;
        [SerializeField] protected EnemyController controller;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            controller = transform.parent.GetComponent<EnemyController>();
            target = (target == null) ? GameObject.Find("Player").transform : target;
            LoadPointSpawn();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
           // attackDelay = (float)levelManagerSO?.GetEnemySOByName(transform.parent.name)?.AttackDelay;
        }

        protected virtual void LoadPointSpawn() {  /*For Override */  }
    }
}