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

    protected virtual void Shoote(string nameBullet)
    {
        Vector3 position = this.posShoote.parent.position;
        Quaternion rotation = this.posShoote.parent.rotation;
        BulletSpawner.Instance.SpawnInRegion(nameBullet, "Forest", position, rotation);
    }
}
