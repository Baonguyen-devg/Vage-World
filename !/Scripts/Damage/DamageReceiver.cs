using UnityEngine;

namespace DamageReceiver
{
    public abstract class DamageReceiver : AutoMonobehaviour
    {
        [Header(header: "The Object's currentHealth informations"), Space(height: 10)]
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maximumHealth;

        [Space(height: 10), SerializeField] protected bool isDead = false;

        public int CurrentHealth => this.currentHealth;

        protected override void LoadComponent() => this.ResetHealthToMaximum();
        protected virtual void OnEnable() => this.ResetHealthToMaximum();
        protected virtual void FixedUpdate() => this.CheckDead();

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