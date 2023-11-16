using UnityEngine;

namespace Attack
{
    public class CloseCombatAttack : Attack
    {
        [SerializeField] protected Transform target;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            LoadTarget();
        }

        protected virtual void LoadTarget() {  /* For override*/  }
    }
}