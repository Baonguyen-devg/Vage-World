using UnityEngine;
using DamageSender;
using Movement;

public class PlayerBulletController : AutoMonobehaviour
{
    [SerializeField] protected BulletMovement movement;
    protected virtual void LoadMovement() => 
        this.movement ??= transform?.Find("Movement")?.GetComponent<BulletMovement>();

    [SerializeField] protected Transform model;
    protected virtual void LoadModel() =>
        this.model ??= transform?.Find("Model");

    [SerializeField] protected PlayerDamageSender damageSender;
    public PlayerDamageSender DamageSender => this.damageSender;
    protected virtual void LoadDamagedSender() =>
        this.damageSender ??= transform?.Find("DamageSender")?.GetComponent<PlayerDamageSender>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadModel();
        this.LoadDamagedSender();
    }
}
