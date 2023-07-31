using UnityEngine;

namespace Movement
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private Vector3 directionFollow;

        protected virtual void LoadSpeed() =>
            this.speed = (float)this.levelManagerSO?.GetEnemySOByName(transform.parent.name)?.Speed;

        protected override void OnEnable()
        {
            base.OnEnable();
            this.LoadSpeed();
        }

        public void SetDirectionFollow(Vector3 direction) => this.directionFollow = direction;

        protected override void Move() => this.Move(direction: this.directionFollow);

        private void Move(Vector3 direction) =>
             transform.parent.position = Vector3.Lerp(a: transform.parent.position, b: transform.parent.position + direction, t: this.speed);
    }
}