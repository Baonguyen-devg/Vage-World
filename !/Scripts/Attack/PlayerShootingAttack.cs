using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAttack : ShootingAttack
{
    [SerializeField] protected Transform posShoote;
    [SerializeField] protected bool skill1, skill2, skill3;
    [SerializeField] protected List<Transform> pointSpawnsSkillOne;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawnSkillOne();
        this.LoadPosShoote();
    }

    protected virtual void LoadPosShoote() =>
        this.posShoote = (this.posShoote != null) ? this.posShoote
            : transform.Find("PointSpawn");

    protected virtual void LoadPointSpawnSkillOne()
    {
        if (this.pointSpawnsSkillOne.Count != 0) return;
        Transform point = transform.Find("PointSpawnSkill1");

        foreach (Transform pointSpawn in point)
            this.pointSpawnsSkillOne.Add(pointSpawn);
    }

    public virtual void ChangeStatusSkill1(bool Status)
    {
        this.skill1 = Status;
        if (this.skill1 == false) this.SetPosAndStatusShoote("PointSpawn", "PointSpawnSkill1");
        else this.SetPosAndStatusShoote("PointSpawnSkill1", "PointSpawn");
    }

    protected virtual void SetPosAndStatusShoote(string pointSpawn1, string pointSpawn2)
    {
        this.posShoote = transform.Find(pointSpawn1);
        this.posShoote.gameObject.SetActive(true);
        transform.Find(pointSpawn2).gameObject.SetActive(false);
    }

    public virtual void ChangeStatusSkill2(bool Status) => this.skill2 = Status;

    public virtual void ChangeStatusSkill3(bool Status) => this.skill3 = Status;

    protected virtual void ZoomBullet(Transform bullet)
    {
        bullet.Find("Model").localScale += new Vector3(0.5f, 0.5f, 0);
        bullet.GetComponent<PlayerBulletController>().DamageSender.IncreaseDame(20);
    }

    public override void ToAttack()
    {
        base.ToAttack();

        string bullet = (this.skill3) ? BulletSpawner.torandoBullet : BulletSpawner.playerBullet;
        Transform bulletSpawn;

        if (!Input.GetMouseButton(0)) return;

        if (this.skill1 == true)
        {
            foreach (Transform point in this.pointSpawnsSkillOne)
            {
                point.gameObject.SetActive(true);
                bulletSpawn = this.ShooteAndReturnBullet(bullet, point);
                if (this.skill2) this.ZoomBullet(bulletSpawn);
            }
            SkillController.Instance.SetTimeSkillOne(false);
            this.ChangeStatusSkill1(false);
        }
        else
        {
            bulletSpawn = this.ShooteAndReturnBullet(bullet, this.posShoote);
            if (this.skill2) this.ZoomBullet(bulletSpawn);
        }

        transform.Find("PointSpawn").Find("Model").GetComponent<Animator>().SetTrigger("Bow");

        if (this.skill2 == true) SkillController.Instance.SetTimeSkillTwo(false);
        if (this.skill3 == true) SkillController.Instance.SetTimeSkillThree(false);
        this.ChangeStatusSkill2(false);
    }

    protected virtual Transform ShooteAndReturnBullet(string nameBullet, Transform posShoote)
    {
        this.attackTimer = 0;
        Transform bullet = this.GetBulletByName(nameBullet, posShoote);
        if (bullet.name == "Tornado_Bullet") bullet.Find("Model").transform.rotation = Quaternion.Euler(0, 0, 0);
        return bullet;
    }
}
