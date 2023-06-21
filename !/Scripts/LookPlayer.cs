using UnityEngine;
using Movement;
using Pathfinding;

public class LookPlayer : AutoMonobehaviour
{
    [SerializeField] protected EnemyController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyController();
    }

    protected virtual void LoadEnemyController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Enemy Controller", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        if (this.controller.gameObject.GetComponent<AIDestinationSetter>().target == null) return;

        if (transform.parent.localPosition.x > this.controller.gameObject.GetComponent<AIDestinationSetter>().target.localPosition.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
