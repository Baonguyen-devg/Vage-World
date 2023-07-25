using UnityEngine;

namespace DamageReceiver
{
    public class PlayerDamageReceiver : DamageReceiver
    {
        [SerializeField] protected float timeEffect = 0.2f;

        [SerializeField] protected Animator redScreen;
        protected virtual void LoadRedScreen() =>
            this.redScreen ??= GameObject.Find("Camera").transform.Find("Main Camera").Find("RedScreen").GetComponent<Animator>();

        [SerializeField] protected SpriteRenderer render;
        protected virtual void LoadRender() =>
            this.render ??= this.controller.Model.GetComponent<SpriteRenderer>();

        [SerializeField] protected PlayerController controller;
        protected virtual void LoadController() =>
              this.controller ??= transform.parent.GetComponent<PlayerController>();

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadController();
            this.LoadRender();
            this.LoadRedScreen();
        }

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health: health);
            this.redScreen.SetTrigger(name: "RedScreen");
            this.redScreen.transform.parent.parent.GetComponent<Animator>().SetTrigger("Shaking");
            this.HitEffect();
        }

        protected virtual void HitEffect()
        {
            VFXSpawner.Instance.SpawnInRegion("Impact_Sword", "Forest", transform.position, transform.rotation);
            SFXSpawner.Instance.PlaySound("Sound_Red_Screen");
            render.color = new Color32(r: 221, g: 83, b: 11, a: 150);
            Invoke(methodName: "ResetColor", time: this.timeEffect);
        }

        protected virtual void ResetColor() =>
           render.color = new Color32(r: 255, g: 255, b: 255, a: 255);
        
        protected override void OnDead()
        {
            this.controller.Model.GetComponent<Animator>().SetTrigger(name: "Die");
            GameController.Instance.LoseGame();
        }
    }
}
