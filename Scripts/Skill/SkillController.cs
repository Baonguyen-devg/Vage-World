using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : AutoMonobehaviour
{
    [SerializeField] protected static SkillController instance;
    [SerializeField] protected List<Transform> skillPrefab;
    [SerializeField] protected bool OnSkill1, OnSkill2, OnSkill3;
    [SerializeField] protected bool useSKill1, useSkill2, useSkill3;
    [SerializeField] protected float timeSkill1, timeSkill2, timeSkill3;
    [SerializeField] protected PlayerShootingAttack attack;

    public static SkillController Instance => instance;

    public float TimeSkill1 => this.timeSkill1;
    public float TimeSkill2 => this.timeSkill2;
    public float TimeSkill3 => this.timeSkill3;

    protected override void LoadComponent()
    {
        SkillController.instance = this;
        base.LoadComponent();
        this.LoadSkillPrefab();
        this.LoadPlayerAttack();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this.attack != null) return;
        this.attack = GameObject.Find("Player").transform.Find("Attack").GetComponent<PlayerShootingAttack>();
        Debug.Log(transform.name + ": Load Player Shooting Attack", gameObject);
    }

    protected virtual void Update()
    {

        if (Time.time > this.timeSkill1 && this.OnSkill1 && this.useSKill1 == false)
        {
            this.attack.ChangeStatusSkill1(true);
            this.useSKill1 = true;
        }

        if (Time.time > this.timeSkill2 && this.OnSkill2 && this.useSkill2 == false)
        {
            this.attack.ChangeStatusSkill2(true);
            this.useSkill2 = true;
        }

        if (Time.time > this.timeSkill3 && this.OnSkill3 && this.useSkill3 == false)
        {
            this.attack.ChangeStatusSkill3(true);
            this.useSkill3 = true;
        }
    }

    protected virtual void LoadSkillPrefab()
    {
        if (this.skillPrefab.Count != 0) return;
        Transform skills = transform.Find("SkillPrefab");

        foreach (Transform prefab in skills)
            this.skillPrefab.Add(prefab);
    }

    public virtual Transform GetPrefabByName(string namePrefab)
    {
        foreach (Transform prefab in this.skillPrefab)
            if (namePrefab == prefab.name) return prefab;
        return null;
    }

    public virtual void SetTimeSkillOne(bool status)
    {
        if (this.OnSkill1 == false) this.OnSkill1 = true;
           
        if (status == false)
        {
            this.timeSkill1 = Time.time + this.GetPrefabByName("Skill1").GetComponent<Skill>().TimeDelay;
        }
        this.useSKill1 = false;
    }

    public virtual void SetTimeSkillTwo(bool status)
    {
        if (this.OnSkill2 == false) this.OnSkill2 = true;
        if (status == false) this.timeSkill2 = Time.time + this.GetPrefabByName("Skill2").GetComponent<Skill>().TimeDelay;
        this.useSkill2 = false;
    }

    public virtual void SetTimeSkillThree(bool status)
    {
        if (this.OnSkill3 == false) this.OnSkill3 = true;
        if (status == false) this.timeSkill3 = Time.time + this.GetPrefabByName("Skill3").GetComponent<Skill>().TimeDelay;
        this.useSkill3 = false;
    }

}
