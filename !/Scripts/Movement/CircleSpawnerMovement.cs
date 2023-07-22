using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnerMovement : CircleMovement
{
    protected override void LoadTargetFollow() =>
     this.targetFollow = GameObject.Find(name: "Boss_Demon")?.transform;

    protected override void Move(Vector3 posToMove) =>
        transform.parent.position = posToMove;
}
