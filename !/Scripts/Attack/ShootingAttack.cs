using UnityEngine;

public class ShootingAttack : Attack
{
    [SerializeField] protected Transform target;

    public void SetTarget(Transform target) { this.target = target; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        //For override
    }

    protected virtual void Shoote(string nameBullet, Transform posShoote)
    {
        this.attackTimer = 0;
        Vector3 position = posShoote.position;
        Quaternion rotation = posShoote.rotation;
        Transform bullet = this.GetBulletByName(nameBullet, posShoote);
        if (bullet.name == "Tornado_Bullet") bullet.Find("Model").transform.rotation = Quaternion.Euler(0, 0, 0);
        this.HaveSkill2(bullet);
    }

    protected virtual Transform ShooteReturnBullet(string nameBullet, Transform posShoote)
    {
        this.attackTimer = 0;
        Vector3 position = posShoote.position;
        Quaternion rotation = posShoote.rotation;
        Transform bullet = this.GetBulletByName(nameBullet, posShoote);
        if (bullet.name == "Tornado_Bullet") bullet.Find("Model").transform.rotation = Quaternion.Euler(0, 0, 0);
        this.HaveSkill2(bullet);
        return bullet;
    }

    protected virtual Transform GetBulletByName(string nameBullet, Transform pos)
    {
        return BulletSpawner.Instance.SpawnInRegion(nameBullet, "Forest", pos.position, pos.rotation);
    }

    protected virtual void HaveSkill2(Transform bullet)
    {

    }
}
