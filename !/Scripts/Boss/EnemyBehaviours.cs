using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviours : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listBehaviours;
    [SerializeField] protected EnemyController controller;
    protected virtual void LoadController() =>
        this.controller ??= transform?.parent?.GetComponent<EnemyController>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
        this.LoadListBehaviours();
    }

    protected virtual void LoadListBehaviours()
    {
        if (this.listBehaviours.Count != 0) return;
        foreach (Transform behaviour in transform)
            this.listBehaviours.Add(item: behaviour);
    }
}
