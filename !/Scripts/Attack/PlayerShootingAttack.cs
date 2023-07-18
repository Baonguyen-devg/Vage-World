using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAttack : ShootingAttack
{
    [SerializeField] protected bool skill1, skill2, skill3;

    [SerializeField] protected List<Transform> pointShootes;
    protected virtual void LoadPointShootes()
    {
        if (this.pointShootes.Count != 0) return;
        foreach (Transform supporter in transform)
            this.pointShootes.Add(item: supporter.Find("Book")?.Find("Point")?.transform);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointShootes();
    }

    public virtual void SetActiveTeamSupporter(bool status)
    {
        for (int i = 0; i < this.pointShootes.Count; i++)
        {
            if (i == 0) continue;
            this.pointShootes[i].parent.gameObject.SetActive(status);
            this.pointShootes[i].parent.parent.Find("Model").gameObject.SetActive(status);
        }
    }

    public virtual void ChangeStatusSkill1(bool Status)
    {
        this.skill1 = Status;
        if (this.skill1 == false) this.SetActiveTeamSupporter(false);
        else this.SetActiveTeamSupporter(true);
    }

    public virtual void ChangeStatusSkill2(bool Status) => this.skill2 = Status;

    public virtual void ChangeStatusSkill3(bool Status) => this.skill3 = Status;

    protected virtual void ZoomBullet(Transform bullet)
    {
        bullet.Find(n: "Model").localScale += new Vector3(1, 1, 0);
        bullet.GetComponent<PlayerBulletController>().DamageSender.IncreaseDame(dame: 20);
    }
    
    public override void ToAttack()
    {
        base.ToAttack();
        if (!Input.GetMouseButton(button: 0)) return;

        string bullet = (this.skill3) ? BulletSpawner.torandoBullet : BulletSpawner.playerBullet;

        foreach (Transform point in this.pointShootes)
        {
            if (!point.gameObject.activeInHierarchy) continue;
            Transform bulletSpawn = this.ShooteAndReturnBullet(nameBullet: bullet, posShoote: point);
            if (this.skill2) this.ZoomBullet(bullet: bulletSpawn);
        }

        if (this.skill1 == true) SkillController.Instance.SetTimeSkillOne(status: false);
        this.ChangeStatusSkill1(Status: false);

        if (this.skill3 == true) SkillController.Instance.SetTimeSkillThree(status: false);
        this.ChangeStatusSkill3(Status: false);

        if (this.skill2 == true) SkillController.Instance.SetTimeSkillTwo(status: false);
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
