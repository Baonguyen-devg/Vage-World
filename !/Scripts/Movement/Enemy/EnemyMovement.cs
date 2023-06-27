using UnityEngine;

namespace Movement
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private Vector3 directionFollow;
        [SerializeField] private bool stopMove = false;

        public void SetDirectionFollow(Vector3 direction) => this.directionFollow = direction;

        private void Move(Vector3 direction) =>
             transform.parent.position = Vector3.Lerp(transform.parent.position, transform.parent.position + direction, this.speed);

        public virtual void SetStopMove(bool status) => this.stopMove = status;

        protected override void Move()
        {
            if (!this.stopMove) return;
            this.Move(this.directionFollow);
        }
    }
}