using UnityEngine;

public class ItemController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform frame;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        model = transform.Find("Model");
        frame = transform.Find("Frame");
    }

    public Transform Model => model;
    public Transform Frame => frame;
}
