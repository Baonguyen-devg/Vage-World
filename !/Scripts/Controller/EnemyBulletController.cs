using UnityEngine;
using DamageSender;
using Movement;

public class EnemyBulletController : AutoMonobehaviour
{
    [SerializeField] private BulletMovement _movement;
    [SerializeField] private Transform _model;
    [SerializeField] private EnemyDamageSender _damageSender;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _movement = transform.Find("Movement").GetComponent<BulletMovement>();
        _model = transform.Find("Model");
        _damageSender = transform.Find("DamageSender").GetComponent<EnemyDamageSender>();
    }
    #endregion

    public Transform Model => _model;
    public EnemyDamageSender DamageSender => _damageSender;
    public BulletMovement Movement => _movement;
}
