using UnityEngine;

public class BulletSpawner : Spawner
{
    public static readonly string BULLET_PLAYER = "Player_Bullet";
    public static readonly string BULLET_TORNADO = "Tornado_Bullet";
    public static readonly string BULLET_DRAGONFLY = "DragonFly_Bullet";
    public static readonly string BULLET_STONE = "Stone_Bullet";
    public static readonly string BULLET_LASER = "Laser_Bullet";

    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_Bullet";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
       BulletSpawner.instance = this;
    }
}
