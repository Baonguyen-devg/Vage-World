using Pathfinding;

public class IdleBehaviour : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.SetStopMove(false);
    }
}
