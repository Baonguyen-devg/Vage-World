using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public class PlayerDamageSender : DamageSender
    {
        private readonly string PATH = "Characters/Player";

        [Header("[ Player Scriptable Object ]"), Space(10)]
        [SerializeField] private CharacterSO playerSO;

        protected virtual void LoadDamage() => dame = playerSO.GetDame();
        private void LoadLevelManagerSO() => playerSO = Resources.Load<CharacterSO>(PATH);

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.OnEnable();
            LoadLevelManagerSO();
            LoadDamage();
        }

        public override void Send(Transform obj)
        {
            obj.GetComponentInChildren<EnemyDamageReceiver>()?.DecreaseHealth(dame);
            obj.GetComponent<BossDemonEnemyDamageReceiver>()?.DecreaseHealth(dame);
        }
    }
}