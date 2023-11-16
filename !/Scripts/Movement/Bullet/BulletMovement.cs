using UnityEngine;

namespace Movement
{
    public class BulletMovement : Movement
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private Transform player;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            player = GameObject.Find("Player").transform;
        }

        protected override void OnEnable()
        {
            Vector3 mousePos = Manager.InputManager.GetInstance().GetMousePosition();
            Vector2 betweenMousePlayer = mousePos - transform.parent.position;

            float rate = betweenMousePlayer.magnitude / betweenMousePlayer.normalized.magnitude;
            Vector2 direc = rate * betweenMousePlayer.normalized;

            direction = direc.normalized;
            RotationFollowPosition(direc.normalized);
        }

        protected virtual void RotationFollowPosition(Vector2 position)
        {
            float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
            Vector3 newRota = new Vector3(0, 0, angle - 90);
            transform.parent.rotation = Quaternion.Euler(newRota);
        }

        protected override void Move() => transform.parent.position += direction * speed;
            //transform.parent.Translate(direction * speed * Time.fixedDeltaTime);

        public virtual void SetDirection(Vector3 direc) => direction = direc;
    }
}