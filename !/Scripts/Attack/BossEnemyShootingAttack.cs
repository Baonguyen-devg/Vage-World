using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class BossEnemyShootingAttack : EnemyShootingAttack
    {
        [SerializeField] private Transform pointShooteStone;
        [SerializeField] private List<Transform> pointsShooteLaser;

        protected override void LoadPointSpawn()
        {
            pointShooteStone = transform.Find("PointShooteStone");
            Transform points = transform.Find("PointsShooteLaser");

            if (pointsShooteLaser.Count != 0) pointsShooteLaser.Clear();
            foreach (Transform pointShoote in points)
                pointsShooteLaser.Add(pointShoote);
        }

        public virtual void ToAttack(string nameBullet)
        {
            if (nameBullet.Equals(BulletSpawner.BULLET_STONE))
                Shoote(nameBullet, pointShooteStone);

            if (nameBullet.Equals(BulletSpawner.BULLET_LASER))
                foreach (Transform pointShoote in pointsShooteLaser)
                    Shoote(nameBullet, pointShoote);
        }
    }
}