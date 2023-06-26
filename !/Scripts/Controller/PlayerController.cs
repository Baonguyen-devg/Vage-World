using UnityEngine;
using DamageReceiver;

public class PlayerController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected PlayerDamageReceiver damageReceiver;

    public PlayerDamageReceiver DamageReceiver => this.damageReceiver;
    public Transform Model => this.model;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.Find("DamageReceiver").GetComponent<PlayerDamageReceiver>();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }
}
