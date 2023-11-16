using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PointAttack : PointSpawnMovement
    {
        protected virtual void Update() => RotationFollowPosition(GetPos());

        protected override void RotationFollowPosition(Vector2 position)
        {
            float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
            Vector3 newRota = new Vector3(0, 0, angle - 90);
            transform.parent.rotation = Quaternion.Euler(newRota);
        }

        protected override Vector2 GetPos()
        {
            Vector3 mousePos = Manager.InputManager.GetInstance().GetMousePosition() ;
            return (mousePos - transform.parent.position).normalized;
        }
    }
}