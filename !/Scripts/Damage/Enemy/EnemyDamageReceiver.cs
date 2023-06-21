using System.Collections;
using UnityEngine;

namespace DamageReceiver
{
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected EnemyController controller;

        [Header("Hit Effect!!!"), Space(10)]
        [SerializeField] protected SpriteRenderer render = null; //SpriteRender in model of enemy
        [SerializeField] protected float timeEffect = 0.2f; //Time effect happen

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadEnemyController();
            this.LoadSpriteRender();
        }

        protected virtual void LoadEnemyController() => 
            this.controller ??= transform.parent.GetComponent<EnemyController>();

        protected virtual void LoadSpriteRender() =>
            this.render ??= this.controller?.Model?.GetComponent<SpriteRenderer>();

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health);
            this.HitEffect();
            this.UpgradeAndAppearHealthBar();
        }
 
        //BEGIN: Effect when enemies receive damage;
        //Change model to RED (211, 83, 11, 255) color when receive damage
        protected virtual void HitEffect()
        {
            render.color = new Color32(221, 83, 11, 255);
            Invoke("ResetColor", this.timeEffect);
        }

        //Change model to normal (255, 255, 255, 255) color after timeEffect
        protected virtual void ResetColor() =>
           render.color = new Color32(255, 255, 255, 255);
        
        //BEGIN: Behaviour to Health Bar;
        protected virtual void UpgradeAndAppearHealthBar()
        {
            this.controller.HealthBar.ChangeHealthBar(this.CalculatePercentHealth());
            this.controller.HealthBar.transform.parent.gameObject.SetActive(true);
            Invoke("DisappearHealthbar", 1f);
        }

        protected virtual float CalculatePercentHealth() =>
         (float)this.currentHealth / this.maximumHealth;

        protected virtual void DisappearHealthbar() =>
            this.controller.HealthBar.transform.parent.gameObject.SetActive(false);
            
        protected override void OnDead()
        {
            EnemySpawner.Instance.Despawn(transform.parent);
        }
    }
}