using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;

    public Transform Model => this.model;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }
}
