using UnityEngine;

namespace Movement
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private Vector3 directionFollow;

       /* protected virtual void LoadSpeed() =>
            speed = (float)levelManagerSO?.GetEnemySOByName(transform.parent.name)?.Speed;*/

        protected override void OnEnable()
        {
            base.OnEnable();
           // LoadSpeed();
        }

        public void SetDirectionFollow(Vector3 direction) => directionFollow = direction;

        protected override void Move() => Move(directionFollow);

        private void Move(Vector3 direction) =>
             transform.parent.position = Vector3.Lerp(transform.parent.position, transform.parent.position + direction, t: speed);
    }
}