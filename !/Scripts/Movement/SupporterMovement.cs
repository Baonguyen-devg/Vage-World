using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterMovement : CircleMovement
{
    protected override void LoadTargetFollow() =>
        this.targetFollow = GameObject.Find(name: "Player")?.transform;

    protected override void Move(Vector3 posToMove) =>
        transform.parent.position = posToMove;
}
