using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerPointSpawnMovement : PointSpawnMovement
    {
        [SerializeField] private float distanceToObject = 0.5f;
        [SerializeField] private float speed = 0.05f;

        protected virtual void Update()
        {
            Vector3 direction = GetPos();
            direction.Normalize();

            Vector3 target = transform.parent.parent.position + direction * distanceToObject;
            transform.parent.position = Vector2.Lerp(transform.parent.position, target, speed);
        }

        protected override Vector2 GetPos() => Manager.InputManager.GetInstance().GetMousePosition();
    }
}