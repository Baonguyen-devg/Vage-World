using UnityEngine;
using Movement;
using Pathfinding;

public class RunFastBehavior : Behaviour
{

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.gameObject.SetActive(true);
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("RunShaking");
    }
}
