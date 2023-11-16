using UnityEngine;

namespace DamageReceiver
{
    public class PlayerDamageReceiver : DamageReceiver
    {
        private readonly int TRIGEER_RED_SCREEN = Animator.StringToHash("RedScreen");
        private readonly int TRIGEER_SHAKING = Animator.StringToHash("Shaking");
        private readonly int TRIGEER_DIE = Animator.StringToHash("Die");
        private readonly string PATH = "Characters/Player";

        public static event System.Action PlayerReceiveDamageEvent;

        [Header("[ Player Scriptable Object ]"), Space(10)]
        [SerializeField] private CharacterSO playerSO;
        [SerializeField] private float timeEffect = 0.2f;

        private Animator redScreen;
        private SpriteRenderer render;
        private PlayerController controller;

        private void LoadLevelManagerSO() => playerSO = Resources.Load<CharacterSO>(PATH);
        protected override void OnEnable()
        {
            base.OnEnable();
            LoadLevelManagerSO();
        }

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            redScreen = GameObject.Find("Camera").transform.Find("Main Camera").Find("RedScreen").GetComponent<Animator>();
            controller = transform.parent.GetComponent<PlayerController>();
            render = controller.Model.GetComponent<SpriteRenderer>();

            LoadLevelManagerSO();
            maximumHealth = playerSO.GetHealth();
            currentHealth = maximumHealth;
        }

        public override void DecreaseHealth(int health)
        {
            base.DecreaseHealth(health);
            PlayerReceiveDamageEvent?.Invoke();
            HitEffect();
        }

        protected virtual void HitEffect()
        {
            redScreen.SetTrigger(TRIGEER_RED_SCREEN);
            redScreen.transform.parent.parent.GetComponent<Animator>().SetTrigger(TRIGEER_SHAKING);

            VFXSpawner.Instance.Spawn(VFXSpawner.PICK_ITEM);
            SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_RED_SCREEN);

            render.color = new Color32(r: 221, g: 83, b: 11, a: 150);
            Invoke("ResetColor", timeEffect);
        }

        protected virtual void ResetColor() =>
           render.color = new Color32(r: 255, g: 255, b: 255, a: 255);
        
        protected override void OnDead()
        {
            controller.Model.GetComponent<Animator>().SetTrigger(TRIGEER_DIE);
            GameController.Instance.LoseGame();
        }
    }
}
