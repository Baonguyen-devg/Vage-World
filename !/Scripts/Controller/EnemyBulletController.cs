using UnityEngine;
using DamageSender;
using Movement;

public class EnemyBulletController : AutoMonobehaviour
{
    [SerializeField] protected BulletMovement movement;
    [SerializeField] protected Transform model;
    [SerializeField] protected EnemyDamageSender damageSender;

    public EnemyDamageSender DamageSender => this.damageSender;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadModel();
        this.LoadDamagedSender();
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.Find("Movement").GetComponent<BulletMovement>();
        Debug.Log(transform.name + ": Load BulletMovement", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadDamagedSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.Find("DamageSender").GetComponent<EnemyDamageSender>();
        Debug.Log(transform.name + ": Load DamageSender", gameObject);
    }
}
