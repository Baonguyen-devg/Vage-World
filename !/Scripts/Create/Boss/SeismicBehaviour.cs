using Pathfinding;

public class SeismicBehaviour : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.GetComponent<AIPath>().enabled = false;
    }
}
