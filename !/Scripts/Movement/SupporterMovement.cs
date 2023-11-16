using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterMovement : CircleMovement
{
    [SerializeField] protected Attack.PlayerShootingAttack playerShoote;
    [SerializeField] protected Transform pointShoote;

    protected override void LoadTargetFollow() =>
        targetFollow = GameObject.Find("Player").transform;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        pointShoote = transform.parent.Find("Point");
        playerShoote = transform.parent?.parent?.GetComponent<Attack.PlayerShootingAttack>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        angle = (float)360 / playerShoote.GetPointShootes().Count * playerShoote.GetIndexSupporter(pointShoote);
    }

    protected override void Move(Vector3 posToMove) =>
        transform.parent.position = posToMove;
}
