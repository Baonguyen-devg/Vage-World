using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : Movement
{
    [SerializeField] protected Vector3 target;

    protected override void Move()
    {
        base.Move();
      /*  this.LookAtTarget();*/
        if (this.target == Vector3.zero) this.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.parent.Translate(Vector3.up * this.speed * Time.fixedDeltaTime);
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.target - transform.parent.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }
}
