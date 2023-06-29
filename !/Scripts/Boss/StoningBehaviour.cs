using Pathfinding;
using UnityEngine;

public class StoningBehaviour : Behaviour
{
    protected override void loadEnemyController() =>
        this.ctrll ??= transform?.parent?.parent?.GetComponent<EnemyController>();

    protected override void OnEnable()
    {
        this.ctrll.Movement.gameObject.SetActive(false);
        this.ctrll.transform.
          Find("AttackShoote").GetComponent<BossEnemyShootingAttack>().ToAttack("Stoning_Bullet");
    }
}
