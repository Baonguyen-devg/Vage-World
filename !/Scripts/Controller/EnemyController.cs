using UnityEngine;
using DamageReceiver;
using DamageSender;
using Movement;
using UniRx;

public class EnemyController : AutoMonobehaviour
{
    [SerializeField] private Transform _model;
    [SerializeField] private BehavioursController _behavioursController;
    [SerializeField] private EnemyDamageReceiver _damageReceiver;
    [SerializeField] private EnemyHealthBar _healthBar;

    private Transform _player;
    private bool _isAttack;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _model = transform.Find("Model");
        _healthBar = transform.GetComponentInChildren<EnemyHealthBar>();
        _behavioursController = transform.GetComponentInChildren<BehavioursController>();
        _damageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
        _player = GameObject.Find("Player").transform;
    }
    #endregion

    protected override void LoadComponentInAwakeBefore()
    {
        Observable.EveryUpdate().Subscribe(_ => NearPosRoot()).AddTo(this);
        _healthBar.transform.parent.gameObject.SetActive(false);
    }

    private void NearPosRoot()
    {
        float distance = Vector2.Distance(transform.position, _player.position);
        if (!_isAttack && distance <= 4f)
        {
            _behavioursController.SetTargetFollow(_player);
            _isAttack = true;
        }
    }

    public void SetIsAttack(bool status) => _isAttack = status;
    public Transform Model => _model;
    public BehavioursController BehavioursManager => _behavioursController;
    public EnemyDamageReceiver DamageReceiver => _damageReceiver;
    public EnemyHealthBar HealthBar => _healthBar;
}
