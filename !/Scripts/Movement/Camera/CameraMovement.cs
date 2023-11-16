using UnityEngine;

namespace Movement
{
    internal class CameraMovement : Movement
    {
        [SerializeField] protected Transform player;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            player = GameObject.Find("Player").transform;
        }

        protected override void Move()
        {
            transform.parent.position = Vector3.Lerp(transform.position, player.position, speed);
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -10);
        }
    }
}