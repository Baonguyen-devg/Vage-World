using UnityEngine;

public class StoningBehaviour : Behaviour
{
    protected override void loadEnemyController() =>
        this.ctrll ??= transform?.parent?.parent?.GetComponent<EnemyController>();

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.transform.Find(n: "AttackShoote").GetComponent<BossEnemyShootingAttack>().ToAttack(nameBullet: "Stoning_Bullet");
    }
}
