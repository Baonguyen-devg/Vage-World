using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : AutoMonobehaviour
{
    [SerializeField] protected float speed = 0.05f;
    [SerializeField] protected float maxSpeed = 1;
    [SerializeField] protected float minSpeed = 0.05f;

    [SerializeField] protected bool isMovingFast = false;
    
    protected virtual void FixedUpdate()
    {
        this.Move();
    }

    protected virtual void Move()
    {
        //for override
    }

    protected virtual void Move(Vector3 direct)
    {
        //For override
    }
}
