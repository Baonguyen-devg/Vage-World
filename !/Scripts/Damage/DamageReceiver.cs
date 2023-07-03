using UnityEngine;

namespace DamageReceiver
{
    [RequireComponent(requiredComponent: typeof(BoxCollider2D))]
    public abstract class DamageReceiver : AutoMonobehaviour
    {
        protected const int default_Maximum_Health = 100;
        protected const bool default_Is_Dead = false;

        [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
        [SerializeField] protected LevelManagerSO levelManagerSO = default;
        protected virtual void LoadLevelManagerSO() =>
             this.levelManagerSO ??= Resources.Load<LevelManagerSO>(path: "Level/EasyLevel");

        [Header(header: "The Object's currentHealth informations"), Space(height: 10)]
        [SerializeField] protected int currentHealth = 0;
        [HideInInspector] public int CurrentHealth => this.currentHealth;

        [SerializeField] protected int maximumHealth = default_Maximum_Health;
        [SerializeField] protected bool isDead = default_Is_Dead;

        protected virtual void OnEnable() => this.ResetHealthToMaximum();

        protected virtual void FixedUpdate() => this.CheckDead();

        protected override void LoadComponent() => this.LoadLevelManagerSO();

        protected virtual void CheckDead()
        {
            if (!this.IsDead()) return;
            this.isDead = true;
            this.OnDead();
        }

        protected virtual bool IsDead() => this.currentHealth <= 0;

        protected virtual void ResetHealthToMaximum() =>
            (this.isDead, this.currentHealth) = (false, this.maximumHealth);

        public virtual void IncreaseHealth(int health) =>
            this.currentHealth = Mathf.Min(a: this.maximumHealth, b: this.currentHealth + health);

        public virtual void DecreaseHealth(int health) =>
            this.currentHealth = Mathf.Max(a: 0, b: this.currentHealth - health);

        protected abstract void OnDead();
    }
}