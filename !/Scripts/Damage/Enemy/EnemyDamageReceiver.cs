using System.Collections;
using UnityEngine;

namespace DamageReceiver
{
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected EnemyController controller;
        [SerializeField] protected SpriteRenderer render;
        [SerializeField] protected EnemyHealthBar healthBar;
        [SerializeField] protected float timeEffect = 0.2f;

        #region Load Component Methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            controller = transform.parent.GetComponent<EnemyController>();
            render = controller.Model.GetComponent<SpriteRenderer>();
            healthBar = controller.HealthBar;
        }
        #endregion

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health);
            HitEffect();
            UpgradeAndAppearHealthBar();
        }

        protected virtual void HitEffect()
        {
            Transform effect = VFXSpawner.Instance.Spawn(VFXSpawner.IMPACT_SWORD);
            effect.gameObject.SetActive(true);
            effect.position = transform.position;

            render.color = new Color32(221, 83, 11, 255);
            Extension.StartDelayAction(this, timeEffect, () => ResetColor());
        }

        protected virtual void UpgradeAndAppearHealthBar()
        {
            float percent = CalculatePercentHealth();
            healthBar.ChangeHealthBar(percent);
            healthBar.transform.parent.gameObject.SetActive(true);

            Extension.StartDelayAction(this, 1f, () => DisappearHealthbar());
        }

        protected override void OnDead()
        {
            Effects();
            SpawnCoins();
            AchievementManager.Instance.GetAchievementByName(transform.parent.name).Increase(1);
            EnemySpawner.Instance.Despawn(transform.parent);
        }

        private void Effects()
        {
            SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_SMOKE_ENEMY_DIE);
            Transform effect = VFXSpawner.Instance.Spawn(VFXSpawner.SMOKE_ENEMY_DIE);

            effect.gameObject.SetActive(true);
            effect.position = transform.parent.position;
        }

        protected virtual void SpawnCoins()
        {
            int numberCoin = Random.Range(3, 5);
            while (numberCoin-- != 0)
            {
                Transform coin = LandDecorationSpawner.Instance.Spawn(LandDecorationSpawner.COIN);
                coin.position = transform.parent.position;
                coin.gameObject.SetActive(true);
            }
        }

        protected virtual void DisappearHealthbar() =>
            healthBar.transform.parent.gameObject.SetActive(false);

        protected virtual void ResetColor() => render.color = new Color32(255, 255, 255, 255);
        protected virtual float CalculatePercentHealth() => (float)currentHealth / maximumHealth;
    }
}