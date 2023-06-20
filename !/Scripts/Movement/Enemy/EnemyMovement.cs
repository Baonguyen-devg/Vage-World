using UnityEngine;

namespace Movement
{
    internal class EnemyMovement : Movement
    {
        [SerializeField] protected Transform target;

        public virtual void SetTarget(Transform target) => this.target = target;

        protected override void Move()
        {
            if (this.target == null) return;
            transform.parent.position = Vector3.Lerp(transform.parent.position, this.target.position, this.speed);
        }
    }
}