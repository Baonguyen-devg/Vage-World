using UnityEngine;

namespace Movement
{
    public abstract class Movement : AutoMonobehaviour
    {
        [SerializeField] protected float speed = 0.05f;
        [SerializeField] protected float maximumSpeed = 1;
        [SerializeField] protected float minimumSpeed = 0.05f;

        [SerializeField] protected bool isMovingFast = false;

        protected virtual void FixedUpdate() => this.Move();

        public virtual void IncreaseSpeed(float speed) =>
            this.speed = Mathf.Min(this.maximumSpeed, this.speed + speed); 

        public virtual void DecreaseSpeed(float speed) =>
            this.speed = Mathf.Max(this.minimumSpeed, this.speed - speed);

        protected abstract void Move();
    }
}