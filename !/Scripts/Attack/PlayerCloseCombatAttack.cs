using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class PlayerCloseCombatAttack : CloseCombatAttack
    {
        private readonly int TRIGGER_SLASH_LEFT = Animator.StringToHash("SlashLeft");

        [SerializeField] protected Animator animator;
        [SerializeField] protected Transform sword;
        [SerializeField] private float timeShootePrevious;
        [SerializeField] private float mana;

        public static System.EventHandler Event_PlayerCloseCombat;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            sword = transform.Find("Sword");
            animator = sword.GetComponent<Animator>();
        }

        public virtual bool SwordCloseCombat()
        {
            if (Time.time - timeShootePrevious < attackDelay) return false;
            timeShootePrevious = Time.time;

            SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_SLASH_SWORD); 
            animator.SetTrigger(TRIGGER_SLASH_LEFT);
            return true;
        }

        protected override bool CanAttack()
        {
            bool isMouseButtonDown = Manager.InputManager.GetInstance().IsLeftMousePress();
            return isMouseButtonDown;
        }

        public float GetMana() => mana;
    }
}