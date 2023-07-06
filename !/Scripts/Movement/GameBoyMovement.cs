using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoyMovement : AutoMonobehaviour
{
    protected const float default_Speed = 0.01f;

    [SerializeField] protected Transform player;
    protected virtual void LoadPlayer() =>
        this.player = GameObject.Find(name: "Player")?.transform;

    [SerializeField] protected float speed = default_Speed;
    [SerializeField] protected float distanceToPlayer = 1;
    [SerializeField] protected float angle;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    protected virtual void Update() => Move();

    protected virtual void Move()
    {
        float x = this.player.position.x + this.distanceToPlayer * Mathf.Cos(f: angle);
        float y = this.player.position.y + this.distanceToPlayer * Mathf.Sin(f: angle);
        this.angle = this.angle + this.speed;

        transform.parent.position = new Vector3(x: x, y: y, z: transform.parent.position.z);
    }
}