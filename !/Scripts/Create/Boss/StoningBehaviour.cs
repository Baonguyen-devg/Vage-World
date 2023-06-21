using Pathfinding;

public class StoningBehaviour : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.GetComponent<AIPath>().enabled = false;
        this.ctrll.transform.
          Find("AttackShoote").GetComponent<BossEnemyShootingAttack>().ToAttack("StoneBullet");
    }
}
