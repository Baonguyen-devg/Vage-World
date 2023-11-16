using UnityEngine;
//using UniRx;

namespace Attack
{
    public abstract class Attack : AutoMonobehaviour
    {
        [SerializeField] protected float attackDelay;
        [SerializeField] protected float attackTimer;

        protected override void Awake()
        {
            base.Awake();
           // Observable.EveryUpdate().Subscribe(_ => ToAttack()).AddTo(this);
        }

        public virtual void ToAttack()
        {
            if (!CanAttack()) return;
        }

        protected virtual bool CanAttack()
        {
            attackTimer = attackTimer + Time.deltaTime;
            if (attackTimer < attackDelay) return false;
            return true;
        }
    }
}