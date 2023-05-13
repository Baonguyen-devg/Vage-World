using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform frame;

    public Transform Model => this.model;
    public Transform Frame => this.frame;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadFrame();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadFrame()
    {
        if (this.frame != null) return;
        this.frame = transform.Find("Frame");
        Debug.Log(transform.name + ": Load Frame", gameObject);
    }
}
