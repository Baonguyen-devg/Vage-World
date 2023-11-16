using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleMovement : AutoMonobehaviour
{
    [SerializeField] protected Transform targetFollow;
    protected abstract void LoadTargetFollow();

    [SerializeField] protected float speedRotation = 0.01f;
    [SerializeField] protected float speedMove = 0.01f;
    [SerializeField] protected float distanceToTarget = 1;
    [SerializeField] protected float angle;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => LoadTargetFollow();
    protected virtual void Update() => Move(PosToMove(targetFollow));

    protected virtual Vector3 PosToMove(Transform target)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);

        float distanceXY = distanceToTarget / Mathf.Sqrt(x * x + y * y);
        angle = angle + speedRotation;

        Vector3 pos = new Vector3(target.localPosition.x + x * distanceXY, 
            target.localPosition.y + y * distanceXY, transform.parent.position.z);
        return pos;
    }

    protected abstract void Move(Vector3 posToMove);
}