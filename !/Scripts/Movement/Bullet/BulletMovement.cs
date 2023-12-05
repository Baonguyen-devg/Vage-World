using UnityEngine;

namespace Movement
{
    public class BulletMovement : Movement
    {
        private Vector3 direction;
       
        protected override void OnEnable()
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
            Vector3 mousePos = Manager.InputManager.GetInstance().GetMousePosition();
            Vector2 betweenMousePlayer = mousePos - transform.parent.position;

            Vector2 direc = GetNormalizedDirection(betweenMousePlayer);
            direction = direc.normalized;

            string nameBullet = RemoveCloneString();
            if (nameBullet.Equals(BulletSpawner.BULLET_TORNADO)) return;

            RotationFollowPosition(direc.normalized);
        }

        private string RemoveCloneString()
        {
            int indexClone = transform.parent.name.IndexOf("(Clone)");
         
            if (indexClone == -1) return transform.parent.name;
            return transform.parent.name.Remove(indexClone, "(Clone)".Length);
        }

        private static Vector2 GetNormalizedDirection(Vector2 betweenMousePlayer)
        {
            float rate = betweenMousePlayer.magnitude / betweenMousePlayer.normalized.magnitude;
            Vector2 direc = rate * betweenMousePlayer.normalized;
            return direc;
        }

        protected virtual void RotationFollowPosition(Vector2 position)
        {
            float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
            Vector3 newRota = new Vector3(0, 0, angle - 90);
            transform.parent.rotation = Quaternion.Euler(newRota);
        }

        protected override void Move() => transform.parent.position += direction * speed;
            //transform._pointSpawn.Translate(direction * _speed * Time.fixedDeltaTime);

        public virtual void SetDirection(Vector3 direc) => direction = direc;
    }
}