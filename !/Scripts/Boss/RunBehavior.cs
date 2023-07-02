using Pathfinding;
using UnityEngine;

public class RunBehavior : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.gameObject.SetActive(value: true);
        this.ctrll.Model.GetComponent<Animator>().SetTrigger(name: "Run");
    }
}
