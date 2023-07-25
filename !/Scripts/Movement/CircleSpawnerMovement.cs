using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnerMovement : CircleMovement
{
    [SerializeField] protected float timeCount = 0;
    [SerializeField] protected CircleSpawnersBossDemon circleSpawers;
    protected virtual void LoadCircleSpawners() =>
        this.circleSpawers = transform.parent?.parent?.GetComponent<CircleSpawnersBossDemon>();

    [SerializeField] protected float timeSpreadOut;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        this.LoadCircleSpawners();
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        this.angle = (float)360 / this.circleSpawers.CirclePrefabs.Count *
            this.circleSpawers.GetIndexPrefab(transform.parent);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.parent.position = transform.parent.parent.position;
        this.timeCount = this.timeSpreadOut;
    }

    protected override void Update()
    {
        this.timeCount = this.timeCount - Time.deltaTime;
        if (this.timeCount <= 0) this.Move(this.GetNormailzeDiretionTarget());
        else base.Update();
    }

    protected virtual Vector3 GetNormailzeDiretionTarget()
    {
        Vector3 direction = transform.parent.position - this.targetFollow.position;
        direction.Normalize();
        return transform.parent.position + direction;
    }

    protected override void LoadTargetFollow() =>
     this.targetFollow = GameObject.Find(name: "Boss_Demon")?.transform;

    protected override void Move(Vector3 posToMove) =>
        transform.parent.position = Vector3.Lerp(transform.parent.position, posToMove, this.speedMove);
}
