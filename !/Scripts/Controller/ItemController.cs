using UnityEngine;

public class ItemController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model ??= transform?.Find(n: "Model");

    [SerializeField] protected Transform frame;
    public Transform Frame => this.frame;
    protected virtual void LoadFrame() =>
        this.frame ??= transform?.Find(n: "Frame");

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadFrame();
    }
}
