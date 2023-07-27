using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterMovement : CircleMovement
{
    [SerializeField] protected PlayerShootingAttack playerShoote;
    protected virtual void LoadCircleSpawners() =>
        this.playerShoote = transform.parent?.parent?.GetComponent<PlayerShootingAttack>();

    protected override void LoadTargetFollow() =>
        this.targetFollow = GameObject.Find(name: "Player")?.transform;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        this.LoadCircleSpawners();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.angle = (float)360 / this.playerShoote.PointShootes.Count *
            this.playerShoote.GetIndexPrefab(transform.parent);
    }

    protected override void Move(Vector3 posToMove) =>
        transform.parent.position = posToMove;
}
