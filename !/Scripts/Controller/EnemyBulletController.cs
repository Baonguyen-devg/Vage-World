using UnityEngine;
using DamageSender;
using Movement;

public class EnemyBulletController : AutoMonobehaviour
{
    [SerializeField] protected BulletMovement movement;
    [SerializeField] protected Transform model;
    [SerializeField] protected EnemyDamageSender damageSender;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        movement = transform.Find("Movement")?.GetComponent<BulletMovement>();
        model = transform.Find("Model");
        damageSender = transform.Find("DamageSender")?.GetComponent<EnemyDamageSender>();
    }

    public Transform Model => model;
    public EnemyDamageSender DamageSender => damageSender;
    public BulletMovement Movement => movement;
}
