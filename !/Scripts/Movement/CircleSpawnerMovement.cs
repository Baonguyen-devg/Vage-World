using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnerMovement : CircleMovement
{
    [SerializeField] protected float timeCount = 0;
    [SerializeField] protected BossCirclesActive circleSpawers;
    [SerializeField] protected float timeSpreadOut;
    [SerializeField] protected int index;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        circleSpawers = transform.parent?.parent?.GetComponent<BossCirclesActive>();
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        angle = (float)360 / circleSpawers.CirclePrefabs.Count * index;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.parent.position = transform.parent.parent.position;
        timeCount = timeSpreadOut;
    }

    protected override void Update()
    {
        timeCount = timeCount - Time.deltaTime;
        if (timeCount <= 0) Move(GetNormailzeDiretionTarget());
        else base.Update();
    }

    protected virtual Vector3 GetNormailzeDiretionTarget()
    {
        Vector3 direction = transform.parent.position - targetFollow.position;
        direction.Normalize();
        return transform.parent.position + direction;
    }

    protected override void LoadTargetFollow() =>
     targetFollow = GameObject.Find("Boss_Demon")?.transform;

    protected override void Move(Vector3 posToMove) =>
        transform.parent.position = Vector3.Lerp(transform.parent.position, posToMove, speedMove);
}
