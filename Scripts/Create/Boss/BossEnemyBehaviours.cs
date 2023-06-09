using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBehaviours : EnemyBehaviours
{
    [SerializeField] protected double NextAttack, rateTime;
    [SerializeField] protected int count = 0;
    // Start is called before the first frame update
    protected virtual void Update()
    {
        if (Time.time < this.NextAttack) return;
        this.NextAttack = Time.time + this.rateTime;

        this.controller.Model.GetComponent<Animator>().SetTrigger(this.listBehaviours[this.count].name);
        this.count = (this.count + 1) % this.listBehaviours.Count;
    }
}
