using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleMovement : AutoMonobehaviour
{
    protected const float default_Speed = 0.01f;

    [SerializeField] protected Transform targetFollow;
    protected abstract void LoadTargetFollow();

    [SerializeField] protected float speedRotation = default_Speed;
    [SerializeField] protected float speedMove= default_Speed;
    [SerializeField] protected float distanceToTarget = 1;
    [SerializeField] protected float angle;

    protected override void LoadComponent() => this.LoadTargetFollow();

    protected virtual void Update() => 
        this.Move(posToMove: this.PosToMove(target: this.targetFollow));

    protected virtual Vector3 PosToMove(Transform target)
    {
        float x = Mathf.Cos(f: this.angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(f: this.angle * Mathf.Deg2Rad);

        float distanceXY = this.distanceToTarget / Mathf.Sqrt(x * x + y * y);
        this.angle = this.angle + this.speedRotation;

        Vector3 pos = new Vector3(x:target.localPosition.x + x * distanceXY, 
            y: target.localPosition.y + y * distanceXY, z: transform.parent.position.z);
        return pos;
    }

    protected abstract void Move(Vector3 posToMove);
}