using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DamageReceiver
{
    public class BossDemonEnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected BossDemonController controller;
        [SerializeField] protected SpriteRenderer render = null;
        
        [Header("Hit Effect!!!"), Space(10)]
        [SerializeField] protected float timeEffect = 0.2f;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            controller ??= transform.parent.GetComponent<BossDemonController>();
            render ??= controller?.Model?.GetComponent<SpriteRenderer>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            //LoadMaximumHealth();
            currentHealth = maximumHealth;
        }

        /*protected virtual void LoadMaximumHealth() =>
            maximumHealth = (int)levelManagerSO?.GetEnemySOByName(transform.parent.name)?.MaximumHealth;*/

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health: health);
            HitEffect();
            UpgradeAndAppearHealthBar();
        }

        protected virtual void HitEffect()
        {
            render.color = new Color32(r: 221, g: 83, b: 11, a: 255);
            Invoke(methodName: "ResetColor", time: timeEffect);
        }

        protected virtual void ResetColor() =>
           render.color = new Color32(r: 255, g: 255, b: 255, a: 255);

        protected virtual void UpgradeAndAppearHealthBar()
        {
          
        }

        protected override void OnDead()
        {
            EnemySpawner.Instance.Despawn(obj: transform.parent);
            VFXSpawner.Instance.Spawn("Smoke_Die_Enemy");
            SFXSpawner.Instance.PlaySound("Sound_Smoke_Die_Enemy");
            AchievementController.Instance.GetAchievementByName(transform.parent.name)?.Increase(1);
        }
    }
}