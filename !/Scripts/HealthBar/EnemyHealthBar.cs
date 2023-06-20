using DamageReceiver;
using UnityEngine;

public class EnemyHealthBar : AutoMonobehaviour
{
    [SerializeField] private EnemyDamageReceiver damageReceiver;

    public EnemyDamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagedReceiver();
    }

    protected virtual void LoadDamagedReceiver() =>
        this.damageReceiver ??= transform.parent.parent.GetComponentInChildren<EnemyDamageReceiver>();

    public virtual void ChangeHealthBar(float percent)
    {
        transform.localScale = new Vector2(percent, 1);
    }
}
