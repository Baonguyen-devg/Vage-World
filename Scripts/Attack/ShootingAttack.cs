using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : Attack
{
    [SerializeField] protected Transform posShoote;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPosShoote();
    }

    protected virtual void LoadPosShoote()
    {
        if (this.posShoote != null) return;
        this.posShoote = transform.Find("PointSpawn");
        Debug.Log(transform.name + ": Load PosShoote", gameObject);
    }

    protected virtual void Shoote(string nameBullet, Transform posShoote)
    {
        Vector3 position = posShoote.position;
        Quaternion rotation = posShoote.rotation;
        Transform bullet = BulletSpawner.Instance.SpawnInRegion(nameBullet, "Forest", position, rotation);
        if (bullet.name == "Tornado_Bullet") bullet.Find("Model").transform.rotation = Quaternion.Euler(0, 0, 0);
        this.HaveSkill2(bullet);
    }

    protected virtual void HaveSkill2(Transform bullet)
    {

    }
}
