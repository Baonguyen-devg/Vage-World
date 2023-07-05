using UnityEngine;

public class LaserBehaviour : Behaviour
{
    protected override void loadEnemyController() =>
        this.ctrll ??= transform?.parent?.parent?.GetComponent<EnemyController>();

    protected override void OnEnable()
    {
        this.ctrll.Movement.gameObject.SetActive(value: false);
        this.ctrll.transform.
            Find(n: "AttackShoote").GetComponent<BossEnemyShootingAttack>().ToAttack(nameBullet: "Laser_Bullet");
    }
}
