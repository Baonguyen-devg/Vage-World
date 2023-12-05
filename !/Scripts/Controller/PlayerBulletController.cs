using UnityEngine;
using DamageSender;
using Movement;

public class PlayerBulletController : AutoMonobehaviour
{
    [SerializeField] private Transform _model;
    [SerializeField] private BulletMovement _movement;
    [SerializeField] private PlayerDamageSender _damageSender;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _model = transform.Find("Model");
        _movement = transform.Find("Movement").GetComponent<BulletMovement>();
        _damageSender = transform.Find("DamageSender").GetComponent<PlayerDamageSender>();
    }

    public Transform Model => _model;
    public BulletMovement Movement => _movement;
    public PlayerDamageSender DamageSender => _damageSender;
}
