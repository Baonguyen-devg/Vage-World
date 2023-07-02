using UnityEngine;
using Movement;
using Pathfinding;

public class RunFastBehavior : Behaviour
{

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.gameObject.SetActive(value: true);
        GameObject.Find(name: "Camera").GetComponent<Animator>().SetTrigger(name: "RunShaking");
    }
}
