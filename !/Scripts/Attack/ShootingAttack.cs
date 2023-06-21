using UnityEngine;

public class ShootingAttack : Attack
{
    protected virtual void Shoote(string nameBullet, Transform posShoote)
    {
        this.attackTimer = 0;
        this.GetBulletByName(nameBullet, posShoote);
    }

    protected virtual Transform GetBulletByName(string nameBullet, Transform pos) =>
         BulletSpawner.Instance.SpawnInRegion(nameBullet, "Forest", pos.position, pos.rotation);
}
