using UnityEngine;
using Movement;

public class RunFastBehavior : Behaviour
{

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.GetComponent<EnemyMovement>().IncreaseSpeed(0.03f);
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("RunShaking");
    }
}
