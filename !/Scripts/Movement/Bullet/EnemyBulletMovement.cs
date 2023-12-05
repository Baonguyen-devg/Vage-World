using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    internal class EnemyBulletMovement : Movement
    {
        protected override void Move() =>
            transform.parent.Translate(Vector3.up * this.speed * Time.fixedDeltaTime);
    }
}
