using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class BossEnemyShootingAttack : EnemyShootingAttack
    {
        [SerializeField] private Transform _pointShooteStone;
        [SerializeField] private List<Transform> _pointsShooteLaser = new List<Transform>();

        protected override void LoadPointSpawn()
        {
            _pointShooteStone = transform.Find("PointShooteStone");
            Transform points = transform.Find("PointsShooteLaser");

            if (_pointsShooteLaser.Count != 0) _pointsShooteLaser.Clear();
            foreach (Transform pointShoote in points)
                _pointsShooteLaser.Add(pointShoote);
        }

        public virtual void ToAttack(string nameBullet)
        {
            if (nameBullet.Equals(BulletSpawner.BULLET_STONE))
                Shoote(nameBullet, _pointShooteStone);

            if (nameBullet.Equals(BulletSpawner.BULLET_LASER))
                foreach (Transform pointShoote in _pointsShooteLaser)
                    Shoote(nameBullet, pointShoote);
        }
    }
}