using UnityEngine;
using Movement;
using Pathfinding;

public class RunFastBehavior : Behaviour
{

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.GetComponent<AIPath>().enabled = true;
        this.ctrll.GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("RunShaking");
    }
}
