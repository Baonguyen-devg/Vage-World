using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAttack : ShootingAttack
{
    protected override void ToAttack()
    {
        base.ToAttack();

        if (Input.GetMouseButton(0)) this.Shoote(BulletSpawner.playerBullet);
    }

}
