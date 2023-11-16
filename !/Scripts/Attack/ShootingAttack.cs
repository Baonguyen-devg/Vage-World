using UnityEngine;

namespace Attack
{
    public class ShootingAttack : Attack
    {
        protected virtual void Shoote(string nameBullet, Transform point)
        {
            attackTimer = 0;
            Transform bullet = CreateBulletByName(nameBullet);
            CustomizeBullet(bullet, point);
        }

        protected virtual Transform CreateBulletByName(string nameBullet) =>
            BulletSpawner.Instance.Spawn(nameBullet);

        protected virtual void CustomizeBullet(Transform bullet, Transform point) { /* FOR OVERRIDE */ }
    }
}