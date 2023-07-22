using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleMovement : AutoMonobehaviour
{
    protected const float default_Speed = 0.01f;

    [SerializeField] protected Transform targetFollow;
    protected abstract void LoadTargetFollow();

    [SerializeField] protected float speed = default_Speed;
    [SerializeField] protected float distanceToTarget = 1;
    [SerializeField] protected float angle;

    protected override void LoadComponent() => this.LoadTargetFollow();

    protected virtual void Update() => 
        this.Move(posToMove: this.PosToMove(target: this.targetFollow));

    protected virtual Vector3 PosToMove(Transform target)
    {
        float x = this.targetFollow.position.x + this.distanceToTarget * Mathf.Cos(f: angle);
        float y = this.targetFollow.position.y + this.distanceToTarget * Mathf.Sin(f: angle);
        this.angle = this.angle + this.speed;

        return new Vector3(x: x, y: y, z: transform.parent.position.z);
    }

    protected abstract void Move(Vector3 posToMove);
}