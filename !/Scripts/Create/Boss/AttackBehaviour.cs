using Pathfinding;

public class AttackBehaviour : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.SetStopMove(false);
    }
}
