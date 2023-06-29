using UnityEngine;

public class DecorObjectController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model ??= transform?.Find("Model");

    protected override void LoadComponent() => this.LoadModel();
}
