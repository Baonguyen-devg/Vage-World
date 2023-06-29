using UnityEngine;
using Movement;
using Pathfinding;

public class LookPlayer : AutoMonobehaviour
{
    [SerializeField] protected EnemyController controller;
    protected virtual void LoadEnemyController() =>
        this.controller ??= transform?.parent?.GetComponent<EnemyController>();

    protected override void LoadComponent() => this.LoadEnemyController();

    protected virtual void Update()
    {
        if (this.controller.RandomlyMovement.TargetFollow == null) return;

        if (transform.parent.localPosition.x > this.controller.RandomlyMovement.TargetFollow.localPosition.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
