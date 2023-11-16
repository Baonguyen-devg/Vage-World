using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class DragonEnemyShootingAttack : EnemyShootingAttack
    {
        [SerializeField] protected List<Transform> pointSpawns;
        protected override void LoadPointSpawn()
        {
            if (pointSpawns.Count != 0) return;
            foreach (Transform pointSpawn in transform)
                pointSpawns.Add(pointSpawn);
        }

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            LoadPointSpawn();
        }

        public override void ToAttack()
        {
            foreach (Transform point in pointSpawns)
                Shoote(BulletSpawner.BULLET_DRAGONFLY, point);
        }

        protected override void CustomizeBullet(Transform bullet, Transform point)
        {
            base.CustomizeBullet(bullet, point);
            bullet.position = point.position;
        }
    }
}