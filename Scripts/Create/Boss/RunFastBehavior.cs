using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFastBehavior : Behaviour
{

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.GetComponent<EnemyMovement>().increaseSpeed(0.03f);
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("RunShaking");
    }
}
