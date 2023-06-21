using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShootingAttack : EnemyShootingAttack
{
    [SerializeField] private Transform pointShooteStone;
    [SerializeField] private List<Transform> pointsShooteLaser;

    protected override void LoadPointSpawn()
    {
        this.pointShooteStone ??= this.transform.Find("PointShooteStone");
        Transform points = this.transform.Find("PointsShooteLaser");

        foreach (Transform pointShoote in points)
            this.pointsShooteLaser.Add(pointShoote);
    }

    public virtual void ToAttack(string nameBullet)
    {
        if (nameBullet.Equals("Stoning_Bullet"))
            this.Shoote(nameBullet, this.pointShooteStone);

        if (nameBullet.Equals("Laser_Bullet"))
            foreach (Transform pointShoote in this.pointsShooteLaser)
                this.Shoote(nameBullet, pointShoote);
    }
}
