using UnityEngine;

public class BulletMovement : Movement
{
    protected override void Move()
    {
        base.Move();
        transform.parent.Translate(Vector3.up * this.speed * Time.fixedDeltaTime);
    }
}
