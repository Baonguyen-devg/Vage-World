using UnityEngine;
using DamageReceiver;
using Movement;

public class BossDemonController : AutoMonobehaviour
{
    [SerializeField] private Transform _model;
    [SerializeField] private BossDemonEnemyDamageReceiver _damageReceiver;
    [SerializeField] private BossDemonEnemyMovement _movement;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _model = transform.Find("Model");
        _damageReceiver = transform.Find("DamageReceiver").GetComponent<BossDemonEnemyDamageReceiver>();
        _movement = transform.Find("Movement").GetComponent<BossDemonEnemyMovement>();
    }
    #endregion

    public Transform Model => _model; 
    public BossDemonEnemyDamageReceiver DamageReceiver => _damageReceiver;
    public BossDemonEnemyMovement Movement => _movement;
}
