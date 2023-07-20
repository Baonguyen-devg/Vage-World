using UnityEngine;
using DamageReceiver;
using DamageSender;

public class PlayerController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model ??= transform?.Find("Model");

    [SerializeField] protected PlayerDamageReceiver damageReceiver;
    public PlayerDamageReceiver DamageReceiver => this.damageReceiver;
    protected virtual void LoadDamageReceiver() =>
        this.damageReceiver ??= transform?.Find("DamageReceiver")?.GetComponent<PlayerDamageReceiver>();

    [SerializeField] protected PlayerDamageSender damageSender;
    public PlayerDamageSender DamageSender => this.damageSender;
    protected virtual void LoadDamageSender() =>
        this.damageSender ??= transform?.Find("DamageSender")?.GetComponent<PlayerDamageSender>();

    [SerializeField] protected PlayerCloseCombatAttack closeCombat;
    public PlayerCloseCombatAttack CloseCombat => this.closeCombat;
    protected virtual void LoadCloseCombat() =>
        this.closeCombat ??= transform?.Find("CloseCombat")?.GetComponent<PlayerCloseCombatAttack>();

    [SerializeField] protected PlayerShootingAttack supporters;
    public PlayerShootingAttack Supporters => this.supporters;
    protected virtual void LoadSupporters() =>
        this.supporters ??= transform?.Find("Supporters")?.GetComponent<PlayerShootingAttack>();

    [SerializeField] protected bool closeCombatActive = true;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDamageReceiver();
        this.LoadDamageSender();
        this.LoadCloseCombat();
        this.LoadSupporters();
    }

    protected override void Start()
    {
        base.Start();
        this.SetWeaponStatus(true);
    }

    protected virtual void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) this.closeCombatActive = !this.closeCombatActive;

        if (this.closeCombatActive) this.SetWeaponStatus(true);
        else this.SetWeaponStatus(false);
    }

    protected virtual void SetWeaponStatus(bool status)
    {
        this.closeCombat.gameObject.SetActive(status);
        this.supporters.gameObject.SetActive(!status);
    }
}
