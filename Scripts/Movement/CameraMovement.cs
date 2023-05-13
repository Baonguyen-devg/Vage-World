using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Movement
{
    [SerializeField] protected Transform player;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": Load player", gameObject);
    }

    protected override void Move()
    {
        base.Move();
        transform.parent.position = Vector3.MoveTowards(transform.position, this.player.position, this.speed);
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -10);
    }
}
