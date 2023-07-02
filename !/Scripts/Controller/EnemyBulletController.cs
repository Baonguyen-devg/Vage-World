using UnityEngine;
using DamageSender;
using Movement;

public class EnemyBulletController : AutoMonobehaviour
{
    [SerializeField] protected BulletMovement movement;
    public BulletMovement Movement => this.movement;
    protected virtual void LoadMovement() =>
        this.movement ??= transform?.Find(n: "Movement")?.GetComponent<BulletMovement>();

    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model ??= transform?.Find(n: "Model");

    [SerializeField] protected EnemyDamageSender damageSender;
    public EnemyDamageSender DamageSender => this.damageSender;
    protected virtual void LoadDamagedSender() =>
        this.damageSender ??= transform?.Find(n: "DamageSender")?.GetComponent<EnemyDamageSender>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadModel();
        this.LoadDamagedSender();
    }
}
