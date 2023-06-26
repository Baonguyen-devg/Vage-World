using UnityEngine;

namespace DamageReceiver
{
    public class PlayerDamageReceiver : DamageReceiver
    {
        [SerializeField] protected PlayerController controller;
        [SerializeField] protected SpriteRenderer render;
        [SerializeField] protected Animator redScreen;
        [SerializeField] protected float timeEffect = 0.2f;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadController();
            this.LoadRender();
            this.LoadRedScreen();
        }

        protected virtual void LoadRedScreen() =>
            this.redScreen ??= GameObject.Find("Camera").transform.Find("Main Camera").Find("RedScreen").GetComponent<Animator>();

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health);
            this.redScreen.SetTrigger("RedScreen");
            this.HitEffect();
        }

        protected virtual void LoadRender() =>
            this.render ??= this.controller.Model.GetComponent<SpriteRenderer>();

        protected virtual void HitEffect()
        {
            render.color = new Color32(221, 83, 11, 150);
            Invoke("ResetColor", this.timeEffect);
        }

        protected virtual void ResetColor() =>
           render.color = new Color32(255, 255, 255, 255);
        
        protected virtual void LoadController() =>
              this.controller ??= transform.parent.GetComponent<PlayerController>();

        protected override void OnDead()
        {
            this.controller.Model.GetComponent<Animator>().SetTrigger("Die");
            UIController.Instance.LoseGame();
        }
    }
}
