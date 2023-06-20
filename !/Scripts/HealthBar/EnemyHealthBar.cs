using DamageReceiver;
using UnityEngine;

public class EnemyHealthBar : AutoMonobehaviour
{
    public virtual void ChangeHealthBar(float percent)
        => transform.localScale = new Vector2(percent, 1);
}
