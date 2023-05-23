using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] protected static BulletSpawner instance;
    public static string playerBullet = "Player_Bullet";
    public static string torandoBullet = "Tornado_Bullet";

    public static BulletSpawner Instance => instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        BulletSpawner.instance = this;
    }
}
