using System.Collections;
using UnityEngine;

namespace DamageReceiver
{
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected EnemyController controller;
        protected virtual void LoadEnemyController() =>
            controller ??= transform.parent.GetComponent<EnemyController>();

        [Header(header: "Hit Effect!!!"), Space(height: 10)]
        [SerializeField] protected float timeEffect = 0.2f; //Time effect happen

        [SerializeField] protected SpriteRenderer render = null; //SpriteRender in model of enemy
        protected virtual void LoadSpriteRender() =>
            render = controller?.Model?.GetComponent<SpriteRenderer>();

        protected override void LoadComponent()
        {
            base.LoadComponent();
            LoadEnemyController();
            LoadSpriteRender();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            //LoadMaximumHealth();
            currentHealth = maximumHealth;
        }

       /* protected virtual void LoadMaximumHealth() =>
            maximumHealth = (int)levelManagerSO?.GetEnemySOByName(transform.parent.name)?.MaximumHealth;*/

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health: health);
            HitEffect();
            UpgradeAndAppearHealthBar();
        }

        protected virtual void HitEffect()
        {
            VFXSpawner.Instance.Spawn(VFXSpawner.PICK_ITEM);
            render.color = new Color32(r: 221, g: 83, b: 11, a: 255);
            Invoke(methodName: "ResetColor", time: timeEffect);
        }

        protected virtual void ResetColor() =>
           render.color = new Color32(r: 255, g: 255, b: 255, a: 255);

        protected virtual void UpgradeAndAppearHealthBar()
        {
            controller.HealthBar.ChangeHealthBar(percent: CalculatePercentHealth());
            controller.HealthBar.transform.parent.gameObject.SetActive(value: true);
            Invoke(methodName: "DisappearHealthbar", time: 1f);
        }

        protected virtual float CalculatePercentHealth() =>
         (float)currentHealth / maximumHealth;

        protected virtual void DisappearHealthbar() =>
            controller.HealthBar.transform.parent.gameObject.SetActive(value: false);

        protected override void OnDead()
        {
            SpawnCoins(Random.Range(3, 5));
            VFXSpawner.Instance.Spawn("Smoke_Die_Enemy");
            SFXSpawner.Instance.PlaySound("Sound_Smoke_Die_Enemy");
            AchievementController.Instance.GetAchievementByName(name: transform.parent.name)?.Increase(1);
            EnemySpawner.Instance.Despawn(obj: transform.parent);
        }

        protected virtual void SpawnCoins(int numberCoin)
        {
            for (int i = 0; i < numberCoin; i++)
                LandDecorationSpawner.Instance.Spawn("Coin");
        }
    }
}