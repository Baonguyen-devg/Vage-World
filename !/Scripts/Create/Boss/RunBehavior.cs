using Pathfinding;
using UnityEngine;

public class RunBehavior : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.SetStopMove(true);
        this.ctrll.Model.GetComponent<Animator>().SetTrigger("Run");
    }
}
