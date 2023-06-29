using UnityEngine;
using DamageReceiver;

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

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDamageReceiver();
    }
}
