using UnityEngine;

namespace Movement
{
    internal abstract class PointSpawnMovement : AutoMonobehaviour
    {
        protected virtual void Update() =>
            this.RotationFollowPosition(this.GetPos().normalized);

        protected virtual void RotationFollowPosition(Vector2 position)
        {
            float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
            Vector3 newRota = new Vector3(0, 0, angle - 90);
            transform.parent.parent.rotation = Quaternion.Euler(newRota);
        }

        protected virtual Vector2 GetPos() =>
            Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.parent.position;
    }
}