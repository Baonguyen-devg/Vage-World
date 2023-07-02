using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShootingAttack : EnemyShootingAttack
{
    [SerializeField] private Transform pointShooteStone;
    [SerializeField] private List<Transform> pointsShooteLaser;

    protected override void LoadPointSpawn()
    {
        this.pointShooteStone ??= this.transform.Find(n: "PointShooteStone");
        Transform points = this.transform.Find(n: "PointsShooteLaser");

        foreach (Transform pointShoote in points)
            this.pointsShooteLaser.Add(item: pointShoote);
    }

    public virtual void ToAttack(string nameBullet)
    {
        if (nameBullet.Equals(value: "Stoning_Bullet"))
            this.Shoote(nameBullet: nameBullet, posShoote: this.pointShooteStone);

        if (nameBullet.Equals(value: "Laser_Bullet"))
            foreach (Transform pointShoote in this.pointsShooteLaser)
                this.Shoote(nameBullet: nameBullet, posShoote: pointShoote);
    }
}
