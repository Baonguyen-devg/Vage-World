using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] protected Transform target;
    [SerializeField] protected EnemyController controller;

    public Transform Target => this.target;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
        this.LoadController();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected override void Move()
    {
        base.Move();
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.target.position, this.speed);
        transform.parent.position = newPos;
    }
}
