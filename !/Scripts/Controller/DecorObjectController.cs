using UnityEngine;

public class DecorObjectController : AutoMonobehaviour
{
    [SerializeField] private Transform _model;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent() => _model = transform.Find("Model");
    #endregion

    public Transform Model => _model;
}