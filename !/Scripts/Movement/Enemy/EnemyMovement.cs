using UnityEngine;

namespace Movement
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private Vector3 directionFollow;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadSpeed();
        }

        protected virtual void LoadSpeed() =>
            this.speed = (float)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.Speed;

        public void SetDirectionFollow(Vector3 direction) => this.directionFollow = direction;

        private void Move(Vector3 direction) =>
             transform.parent.position = Vector3.Lerp(transform.parent.position, transform.parent.position + direction, this.speed);

        protected override void Move() => this.Move(this.directionFollow);
    }
}