using UnityEngine;
using DamageReceiver;
using DamageSender;

public class PlayerController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected PlayerDamageReceiver damageReceiver;
    [SerializeField] protected PlayerDamageSender damageSender;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        model = transform.Find("Model");
        damageReceiver = transform.Find("Damage Receiver").GetComponent<PlayerDamageReceiver>();
        damageSender = transform.Find("Damage Sender").GetComponent<PlayerDamageSender>();
    }

    public PlayerDamageReceiver DamageReceiver => damageReceiver;
    public PlayerDamageSender DamageSender => damageSender;
    public Transform Model => model;
}
