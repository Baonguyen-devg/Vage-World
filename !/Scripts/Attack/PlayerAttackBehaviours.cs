using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviours : AutoMonobehaviour
{
    private static PlayerAttackBehaviours instance;
    public static PlayerAttackBehaviours GetInstance()
    {
        if (instance == null) instance = new PlayerAttackBehaviours();
        return instance;
    }

    [SerializeField] protected Attack.PlayerCloseCombatAttack closeCombat;
    [SerializeField] protected Attack.PlayerShootingAttack shooting;
    [SerializeField] protected bool closeCombatActive = true;
    [SerializeField] protected float mana;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        shooting = transform.Find("Shooting").GetComponent<Attack.PlayerShootingAttack>();
        closeCombat = transform.Find("CloseCombat").GetComponent<Attack.PlayerCloseCombatAttack>();
    }

    protected override void Awake()
    {
        base.Awake();
        PlayerAttackBehaviours.instance = this;
    }

    protected virtual void Update()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        bool isFPress = Manager.InputManager.GetInstance().IsFPress();
        if (isFPress) closeCombatActive = !closeCombatActive;

        if (closeCombatActive) SetWeaponStatus(true);
        else SetWeaponStatus(false);
    }

    public virtual bool RequestAttack()
    {
        if (closeCombatActive) return closeCombat.SwordCloseCombat() ;
        else return shooting.SupportShoote();
    }

    protected virtual void SetWeaponStatus(bool status)
    {
        if (status) mana = closeCombat.GetMana();
        else mana = shooting.GetMana();

        closeCombat.gameObject.SetActive(status);
        shooting.gameObject.SetActive(!status);
    }

    public float GetMana() => mana;
    public Attack.PlayerCloseCombatAttack CloseCombat => closeCombat;
    public Attack.PlayerShootingAttack Supporters => shooting;
}
