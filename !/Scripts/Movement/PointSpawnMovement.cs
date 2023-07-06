using UnityEngine;

namespace Movement
{
    public abstract class PointSpawnMovement : AutoMonobehaviour
    {
        protected virtual void RotationFollowPosition(Vector2 position)
        {
            float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
            Vector3 newRota = new Vector3(0, 0, angle - 90);
            transform.parent.parent.rotation = Quaternion.Euler(newRota);
        }

        protected abstract Vector2 GetPos();
    }
}