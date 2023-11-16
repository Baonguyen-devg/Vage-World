using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullLookPlayer : AutoMonobehaviour
{
    [SerializeField] protected Transform player;
    protected virtual void LoadPlayer() =>
        this.player = GameObject.Find("Player")?.transform;

    [SerializeField] protected double distanceChange = 0.5f;

    protected override void LoadComponent() {
        this.LoadPlayer();
    }

    protected virtual void Update()
    {
        if (Mathf.Abs(transform.localPosition.x - this.player.localPosition.x) <= this.distanceChange) return;
        if (transform.localPosition.x > this.player.localPosition.x)
            transform.rotation = Quaternion.Euler(x: 0, y: -180, z: 0);
        else
            transform.rotation = Quaternion.Euler(x: 0, y: 0, z: 0);
    }
}
