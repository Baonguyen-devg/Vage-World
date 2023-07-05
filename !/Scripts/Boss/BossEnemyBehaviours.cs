using UnityEngine;

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

        this.controller.Model.GetComponent<Animator>().SetTrigger(name: this.listBehaviours[this.count].name);
        
        foreach (string nameBehaviour in this.standBehaviours)
            if (nameBehaviour.Equals(value: this.listBehaviours[this.count].name))
                this.controller.Movement.gameObject.SetActive(value: false);

        foreach (string nameBehaviour in this.runBeharviours)
            if (nameBehaviour.Equals(value: this.listBehaviours[this.count].name))
            {
                this.controller.Movement.gameObject.SetActive(value: true);
                if (this.listBehaviours[this.count].name.Equals(value: "RunFast"))
                    this.controller.Movement.IncreaseSpeed(speed: 0.02f);
                else
                    this.controller.Movement.DecreaseSpeed(speed: 0.02f);
            }

        this.count = (this.count + 1) % this.listBehaviours.Count;
    }
}
