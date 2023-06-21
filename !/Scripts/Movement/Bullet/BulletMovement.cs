using UnityEngine;

namespace Movement
{
    public class BulletMovement : Movement
    {
        protected override void Move() =>
            transform.parent.Translate(Vector3.up * this.speed * Time.fixedDeltaTime);
    }
}