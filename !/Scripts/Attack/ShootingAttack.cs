using UnityEngine;

public class ShootingAttack : Attack
{
    protected virtual void Shoote(string nameBullet, Transform posShoote)
    {
        this.attackTimer = 0;
        this.GetBulletByName(nameBullet: nameBullet, pos: posShoote);
    }

    protected virtual Transform GetBulletByName(string nameBullet, Transform pos) =>
         BulletSpawner.Instance.SpawnInRegion(nameObject: nameBullet, nameRegion: "Forest", postion: pos.position, rotation: pos.rotation);
}
