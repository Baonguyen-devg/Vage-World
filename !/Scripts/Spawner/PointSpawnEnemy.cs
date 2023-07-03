using System.Collections.Generic;
using UnityEngine;

public class PointSpawnEnemy : AutoMonobehaviour
{
    [SerializeField] private List<Transform> listEnemy;
    [SerializeField] private bool requestAttack;
    [SerializeField] private double timeStopAttack;
    [SerializeField] private double rateTimeAttack;

    public virtual void Add(Transform enemy) => this.listEnemy.Add(item: enemy);

    public virtual void Update()
    {
        if (this.requestAttack == true)
            this.timeStopAttack = Time.time + this.rateTimeAttack;

        if (this.requestAttack == false && Time.time >= this.timeStopAttack)
            foreach (Transform enemy in this.listEnemy)
                enemy.GetComponent<EnemyController>().StopAttack();
    }

    public virtual void RequestEnemiesAttack()
    {
        this.requestAttack = true;
        foreach (Transform enemy in this.listEnemy)
            enemy.GetComponent<EnemyController>().DoAttack();
    }

    public virtual void RequestEnemiesStopAttack() => this.requestAttack = false;
}
