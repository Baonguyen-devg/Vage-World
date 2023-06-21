using Pathfinding;
using UnityEngine;

public class RunBehavior : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.GetComponent<AIPath>().enabled = true;
        this.ctrll.GetComponent<AIPath>().maxSpeed = 2;
        this.ctrll.Model.GetComponent<Animator>().SetTrigger("Run");
    }
}