using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAttack : ShootingAttack
{
    [SerializeField] protected List<Transform> pointSpawnsSkillOne;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawnSkillOne();
    }

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
        if (this.skill1 == false)
        {
            this.posShoote = transform.Find("PointSpawn");
            this.posShoote.gameObject.SetActive(true);
            transform.Find("PointSpawnSkill1").gameObject.SetActive(false);
        }
        else
        {
            this.posShoote = transform.Find("PointSpawnSkill1");
            this.posShoote.gameObject.SetActive(true);
            transform.Find("PointSpawn").gameObject.SetActive(false);
        }
    }

    public virtual void ChangeStatusSkill2(bool Status)
    {
        this.skill2 = Status;
    }

    public virtual void ChangeStatusSkill3(bool Status)
    {
        this.skill3 = Status;
    }

    protected override void ToAttack()
    {
        base.ToAttack();

        string bullet = (this.skill3) ? BulletSpawner.torandoBullet : BulletSpawner.playerBullet;

        if (Input.GetMouseButton(0))
        {
            if (this.skill1 == true)
            {
                foreach (Transform point in this.pointSpawnsSkillOne)
                {
                    point.gameObject.SetActive(true);
                    this.Shoote(bullet, point);
                }
                SkillController.Instance.SetTimeSkillOne(false);
                this.ChangeStatusSkill1(false);
            }
            else this.Shoote(bullet, this.posShoote);

            if (this.skill2 == true) SkillController.Instance.SetTimeSkillTwo(false);
            if (this.skill3 == true) SkillController.Instance.SetTimeSkillThree(false);
            this.ChangeStatusSkill2(false);
            this.ChangeStatusSkill3(false);
        }
    }

    protected override void HaveSkill2(Transform bullet)
    {
        base.HaveSkill2(bullet);
        if (this.skill2 == false) return;
        bullet.Find("Impact").GetComponent<BulletImpact>().ChangeStatusSkill2(true);
    }
}