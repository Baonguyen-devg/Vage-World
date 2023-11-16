using UnityEngine;
using DamageSender;
using Movement;

public class PlayerBulletController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected BulletMovement movement;
    [SerializeField] protected PlayerDamageSender damageSender;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        model = transform.Find("Model");
        movement = transform.Find("Movement").GetComponent<BulletMovement>();
        damageSender = transform.Find("DamageSender").GetComponent<PlayerDamageSender>();
    }

    public Transform Model => model;
    public BulletMovement Movement => movement;
    public PlayerDamageSender DamageSender => damageSender;
}
