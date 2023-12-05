using UnityEngine;

namespace DamageReceiver
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class DamageReceiver : AutoMonobehaviour
    {
        [Header("The Object's currentHealth informations"), Space(10)]
        [SerializeField] protected int currentHealth = 0;

        [SerializeField] protected int maximumHealth = 100;
        [SerializeField] protected bool isDead = false;

        protected override void OnEnable() => ResetHealthToMaximum();
        protected virtual void Update() => CheckDead();

        protected virtual void CheckDead()
        {
            if (!IsDead() || isDead) return;
            isDead = true;
            OnDead();
        }

        protected virtual bool IsDead() => currentHealth <= 0;

        protected virtual void ResetHealthToMaximum() =>
            (isDead, currentHealth) = (false, maximumHealth);

        public virtual void IncreaseHealth(int health) =>
            currentHealth = Mathf.Min(maximumHealth, currentHealth + health);

        public virtual void DecreaseHealth(int health) =>
            currentHealth = Mathf.Max(0, currentHealth - health);

        protected abstract void OnDead();
        public virtual int GetMaximumHealth() => maximumHealth;
        public virtual int GetCurrentHealth() => currentHealth;
    }
}