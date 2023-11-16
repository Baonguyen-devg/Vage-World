using UnityEngine;

namespace Movement
{
    public abstract class Movement : AutoMonobehaviour
    {
        protected const float default_Speed = 0.02f;
        protected const float default_Maximum_Speed = 1;
        protected const float default_Minimum_Speed = 0.01f;    

        [SerializeField] protected float speed = default_Speed;
        [SerializeField] protected float maximumSpeed = default_Maximum_Speed;
        [SerializeField] protected float minimumSpeed = default_Minimum_Speed;
        [SerializeField] protected bool isMovingFast = false;
      
        protected virtual void Update() => Move();

        public virtual void IncreaseSpeed(float _speed) =>
            speed = Mathf.Min(maximumSpeed, speed + _speed); 

        public virtual void DecreaseSpeed(float _speed) =>
            speed = Mathf.Max(minimumSpeed, speed - _speed);

        protected abstract void Move();
    }
}