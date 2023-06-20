using UnityEngine;

namespace Movement
{
    internal class CameraMovement : Movement
    {
        [SerializeField] protected Transform player;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadPlayer();
        }

        protected virtual void LoadPlayer() =>
            this.player ??= GameObject.Find("Player").transform;

        protected override void Move()
        {
            transform.parent.position = Vector3.MoveTowards(transform.position, this.player.position, this.speed);
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -10);
        }
    }
}