using UnityEngine;

namespace DamageReceiver
{
    internal abstract class DamageReceiver : AutoMonobehaviour
    {
        [Header("The Object's currentHealth informations"), Space(10)]
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maximumHealth;

        [Space(10), SerializeField] protected bool isDead = false;

        protected virtual void OnEnable() => this.ResetHealthToMaximum();

        protected virtual void FixedUpdate() => this.CheckDead();

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.ResetHealthToMaximum();
        }

        protected virtual void CheckDead()
        {
            if (this.IsDead())
            {
                this.isDead = true;
                this.OnDead();
            }
        }

        protected virtual bool IsDead() => this.currentHealth <= 0;

        protected virtual void ResetHealthToMaximum() =>
            (this.isDead, this.currentHealth) = (false, this.maximumHealth);


        protected virtual void IncreaseHealth(int health) =>
            this.currentHealth = this.isDead ? this.currentHealth 
            : Mathf.Min(this.maximumHealth, this.currentHealth + health);


        protected virtual void DecreaseHealth(int health) =>
            this.currentHealth = (this.isDead) ? this.currentHealth
            : Mathf.Max(0, this.currentHealth - health);

        protected abstract void OnDead();
    }
}