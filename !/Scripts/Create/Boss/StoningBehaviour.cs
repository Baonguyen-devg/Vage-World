using Pathfinding;
using UnityEngine;

public class StoningBehaviour : Behaviour
{
    protected override void loadEnemyController()
    {
        if (this.ctrll != null) return;
        this.ctrll = transform.parent.parent.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyController", gameObject);
    }

    protected override void OnEnable()
    {
        this.ctrll.Movement.SetStopMove(false);
        this.ctrll.transform.
          Find("AttackShoote").GetComponent<BossEnemyShootingAttack>().ToAttack("Stoning_Bullet");
    }
}
