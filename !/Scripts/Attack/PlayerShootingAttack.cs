using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAttack : ShootingAttack
{
    [SerializeField] protected Transform posShoote;
    protected virtual void LoadPosShoote() =>
        this.posShoote = (this.posShoote != null) ? this.posShoote
            : transform.Find(n: "PointSpawn");

    [SerializeField] protected bool skill1, skill2, skill3;

    [SerializeField] protected List<Transform> pointSpawnsSkillOne;
    protected virtual void LoadPointSpawnSkillOne()
    {
        if (this.pointSpawnsSkillOne.Count != 0) return;
        Transform point = transform.Find(n: "PointSpawnSkill1");

        foreach (Transform pointSpawn in point)
            this.pointSpawnsSkillOne.Add(item: pointSpawn);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawnSkillOne();
        this.LoadPosShoote();
    }

    public virtual void ChangeStatusSkill1(bool Status)
    {
        this.skill1 = Status;
        if (this.skill1 == false) 
            this.SetPosAndStatusShoote(pointSpawn1: "PointSpawn", pointSpawn2: "PointSpawnSkill1");
        else 
            this.SetPosAndStatusShoote(pointSpawn1: "PointSpawnSkill1", pointSpawn2: "PointSpawn");
    }

    protected virtual void SetPosAndStatusShoote(string pointSpawn1, string pointSpawn2)
    {
        this.posShoote = transform.Find(n: pointSpawn1);
        this.posShoote.gameObject.SetActive(value: true);
        transform.Find(n: pointSpawn2).gameObject.SetActive(value: false);
    }

    public virtual void ChangeStatusSkill2(bool Status) => this.skill2 = Status;

    public virtual void ChangeStatusSkill3(bool Status) => this.skill3 = Status;

    protected virtual void ZoomBullet(Transform bullet)
    {
        bullet.Find(n: "Model").localScale += new Vector3(0.5f, 0.5f, 0);
        bullet.GetComponent<PlayerBulletController>().DamageSender.IncreaseDame(dame: 20);
    }

    public override void ToAttack()
    {
        base.ToAttack();

        string bullet = (this.skill3) ? BulletSpawner.torandoBullet : BulletSpawner.playerBullet;
        Transform bulletSpawn;

        if (!Input.GetMouseButton(button: 0)) return;

        if (this.skill1 == true)
        {
            foreach (Transform point in this.pointSpawnsSkillOne)
            {
                point.gameObject.SetActive(value: true);
                bulletSpawn = this.ShooteAndReturnBullet(nameBullet: bullet, posShoote: point);
                if (this.skill2) this.ZoomBullet(bullet: bulletSpawn);
            }
            SkillController.Instance.SetTimeSkillOne(status: false);
            this.ChangeStatusSkill1(Status: false);
        }
        else
        {
            bulletSpawn = this.ShooteAndReturnBullet(nameBullet: bullet, posShoote: this.posShoote);
            if (this.skill2) this.ZoomBullet(bullet: bulletSpawn);
        }

        transform.Find(n: "PointSpawn").Find(n: "Model").GetComponent<Animator>().SetTrigger(name: "Bow");

        if (this.skill2 == true) SkillController.Instance.SetTimeSkillTwo(status: false);
        if (this.skill3 == true) SkillController.Instance.SetTimeSkillThree(status: false);
        this.ChangeStatusSkill2(Status: false);
    }

    protected virtual Transform ShooteAndReturnBullet(string nameBullet, Transform posShoote)
    {
        this.attackTimer = 0;
        Transform bullet = this.GetBulletByName(nameBullet: nameBullet, pos: posShoote);
        if (bullet.name == "Tornado_Bullet") bullet.Find(n: "Model").transform.rotation = Quaternion.Euler(0, 0, 0);
        return bullet;
    }
}
