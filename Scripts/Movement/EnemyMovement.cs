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
        this.LoadController();
    }

    public virtual void SetTarget(Transform target) { this.target = target; }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected override void Move()
    {
        base.Move();
        if (this.target == null) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.target.position, this.speed);
        transform.parent.position = newPos;
    }
}
