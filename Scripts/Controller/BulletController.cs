using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : AutoMonobehaviour
{
    [SerializeField] protected BulletMovement movement;
    [SerializeField] protected Transform model;
    [SerializeField] protected BulletDamagedSender damagedSender;

    public BulletDamagedSender DamagedSender => this.damagedSender;

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
        if (this.damagedSender != null) return;
        this.damagedSender = transform.Find("DamagedSender").GetComponent<BulletDamagedSender>();
        Debug.Log(transform.name + ": Load DamagedSender", gameObject);
    }
}
