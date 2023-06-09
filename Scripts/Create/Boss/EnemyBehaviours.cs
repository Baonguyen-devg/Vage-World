using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviours : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listBehaviours;
    [SerializeField] protected EnemyController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.LoadListBehaviours();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);    
    }

    protected virtual void LoadListBehaviours()
    {
        if (this.listBehaviours.Count != 0) return;
        foreach (Transform behaviour in transform)
            this.listBehaviours.Add(behaviour);
    }
}
