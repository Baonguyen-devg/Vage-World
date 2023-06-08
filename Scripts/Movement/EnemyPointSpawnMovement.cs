using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointSpawnMovement : PointSpawnMovement
{
    [SerializeField] private Transform player;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.player = GameObject.Find("Player").transform;
    }

    protected override Vector2 GetPos()
    {
        return this.player.position - transform.parent.parent.position;
    }
}
