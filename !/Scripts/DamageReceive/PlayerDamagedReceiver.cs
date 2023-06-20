using UnityEngine;

namespace DamageReceiver
{
    internal class PlayerDamagedReceiver : DamageReceiver
    {
        [SerializeField] protected PlayerController controller;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadController();
        }

        protected virtual void LoadController() =>
              this.controller ??= transform.parent.GetComponent<PlayerController>();

        protected override void OnDead()
        {
            this.controller.Model.GetComponent<Animator>().SetTrigger("Die");
            UIController.Instance.LoseGame();
        }
    }
}