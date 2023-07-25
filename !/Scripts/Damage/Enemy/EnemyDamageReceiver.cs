using System.Collections;
using UnityEngine;

namespace DamageReceiver
{
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected EnemyController controller;
        protected virtual void LoadEnemyController() =>
            this.controller ??= transform.parent.GetComponent<EnemyController>();

        [Header(header: "Hit Effect!!!"), Space(height: 10)]
        [SerializeField] protected float timeEffect = 0.2f; //Time effect happen

        [SerializeField] protected SpriteRenderer render = null; //SpriteRender in model of enemy
        protected virtual void LoadSpriteRender() =>
            this.render ??= this.controller?.Model?.GetComponent<SpriteRenderer>();

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadEnemyController();
            this.LoadSpriteRender();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.LoadMaximumHealth();
            this.currentHealth = this.maximumHealth;
        }

        protected virtual void LoadMaximumHealth() =>
            this.maximumHealth = (int)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.MaximumHealth;

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health: health);
            this.HitEffect();
            this.UpgradeAndAppearHealthBar();
        }

        protected virtual void HitEffect()
        {
            VFXSpawner.Instance.SpawnInRegion("Impact_Sword", "Forest", transform.position, transform.rotation);
            render.color = new Color32(r: 221, g: 83, b: 11, a: 255);
            Invoke(methodName: "ResetColor", time: this.timeEffect);
        }

        protected virtual void ResetColor() =>
           render.color = new Color32(r: 255, g: 255, b: 255, a: 255);

        protected virtual void UpgradeAndAppearHealthBar()
        {
            this.controller.HealthBar.ChangeHealthBar(percent: this.CalculatePercentHealth());
            this.controller.HealthBar.transform.parent.gameObject.SetActive(value: true);
            Invoke(methodName: "DisappearHealthbar", time: 1f);
        }

        protected virtual float CalculatePercentHealth() =>
         (float)this.currentHealth / this.maximumHealth;

        protected virtual void DisappearHealthbar() =>
            this.controller.HealthBar.transform.parent.gameObject.SetActive(value: false);

        protected override void OnDead()
        {
            EnemySpawner.Instance.Despawn(obj: transform.parent);
            VFXSpawner.Instance.SpawnInRegion("Smoke_Die_Enemy", "Forest", transform.parent.position, transform.parent.rotation);
            SFXSpawner.Instance.PlaySound("Sound_Smoke_Die_Enemy");
            AchievementController.Instance.GetAchievementByName(name: transform.parent.name)?.Increase(1);
        }
    }
}