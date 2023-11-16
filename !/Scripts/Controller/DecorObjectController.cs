using UnityEngine;

public class DecorObjectController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => model = transform.Find("Model");

    public Transform Model => model;
}