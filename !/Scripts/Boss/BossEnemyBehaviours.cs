using UnityEngine;
using Pathfinding;

public class BossEnemyBehaviours : EnemyBehaviours
{
    [SerializeField] protected string[] standBehaviours = { "Laser", "Stoning", "Seismic", "Idle" };
    [SerializeField] protected string[] runBeharviours = { "Run", "RunFast" };

    [SerializeField] protected double NextAttack, rateTime;
    [SerializeField] protected int count = 0;

    protected virtual void Update()
    {
        if (Time.time < this.NextAttack) return;
        this.NextAttack = Time.time + this.rateTime;

        this.controller.Model.GetComponent<Animator>().SetTrigger(this.listBehaviours[this.count].name);
        
        foreach (string nameBehaviour in this.standBehaviours)
            if (nameBehaviour.Equals(this.listBehaviours[this.count].name))
                this.controller.Movement.gameObject.SetActive(false);

        foreach (string nameBehaviour in this.runBeharviours)
            if (nameBehaviour.Equals(this.listBehaviours[this.count].name))
            {
                this.controller.Movement.gameObject.SetActive(true);
                if (this.listBehaviours[this.count].name.Equals("RunFast"))
                    this.controller.Movement.IncreaseSpeed(0.02f);
                else
                    this.controller.Movement.DecreaseSpeed(0.02f);
            }

        this.count = (this.count + 1) % this.listBehaviours.Count;
    }
}
