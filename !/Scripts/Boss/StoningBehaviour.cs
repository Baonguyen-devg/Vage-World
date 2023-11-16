using UnityEngine;

public class StoningBehaviour : Behaviour
{
    protected override void loadEnemyController() =>
        ctrll ??= transform?.parent?.parent?.GetComponent<EnemyController>();

    protected override void OnEnable()
    {
        base.OnEnable();
        ctrll.transform.Find(n: "AttackShoote").GetComponent<Attack.BossEnemyShootingAttack>().ToAttack(nameBullet: "Stoning_Bullet");
    }
}
