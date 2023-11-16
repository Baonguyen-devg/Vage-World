using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePrefab : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> pointSpawners;
    protected void LoadPointSpawners()
    {
        this.pointSpawners.Clear();
        Transform points = transform.Find("Point_Spawners");
        foreach (Transform point in points)
            this.pointSpawners.Add(item: point);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawners();
    }

    public virtual void Spawner(string nameEnemy)
    {
       /* foreach (Transform point in this.pointSpawners)
            EnemySpawner.Instance.Spawn(nameEnemy, "Forest", point.position, point.rotation);*/
    }
}
