using UnityEngine;
using DamageReceiver;
using DamageSender;

public class PlayerController : AutoMonobehaviour
{
    [SerializeField] private Transform _model;
    [SerializeField] private PlayerDamageReceiver _damageReceiver;
    [SerializeField] private PlayerDamageSender _damageSender;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _model = transform.Find("Model");
        _damageReceiver = transform.Find("Damage Receiver").GetComponent<PlayerDamageReceiver>();
        _damageSender = transform.Find("Damage Sender").GetComponent<PlayerDamageSender>();
    }
    #endregion

    public PlayerDamageReceiver DamageReceiver => _damageReceiver;
    public PlayerDamageSender DamageSender => _damageSender;
    public Transform Model => _model;
}
