using UnityEngine;

public class BossEnemyBehaviours : EnemyBehaviours
{
    [SerializeField] protected string[] standBehaviours = { "Laser", "Stoning", "Seismic", "Idle" };
    [SerializeField] protected string[] runBehaviours = { "Run", "RunFast" };

    [SerializeField] protected double NextAttack, rateTime;
    [SerializeField] protected int count = 0;

    protected virtual void Update()
    {
        if (Time.time < this.NextAttack) return;
        this.NextAttack = Time.time + this.rateTime;
        this.DoBehaviour();
    }

    protected virtual void DoBehaviour() 
    {
        this.controller.Model.GetComponent<Animator>().SetTrigger(name: this.listBehaviours[this.count].name);
        this.SetStandBehaivours();
        this.SetRunBehaviours();
        this.count = (this.count + 1) % this.listBehaviours.Count;
    }

    protected virtual void SetRunBehaviours()
    {
        foreach (string nameBehaviour in this.runBehaviours)
            if (nameBehaviour.Equals(value: this.listBehaviours[this.count].name))
            {
                this.controller.Movement.gameObject.SetActive(value: true);
                if (this.listBehaviours[this.count].name.Equals(value: "RunFast"))
                    this.controller.Movement.IncreaseSpeed(speed: 0.02f);
                else
                    this.controller.Movement.DecreaseSpeed(speed: 0.02f);
            }
    }

    protected virtual void SetStandBehaivours()
    {
        foreach (string nameBehaviour in this.standBehaviours)
            if (nameBehaviour.Equals(value: this.listBehaviours[this.count].name))
                this.controller.Movement.gameObject.SetActive(value: false);
    }
}
