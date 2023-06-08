using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehavior : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.gameObject.SetActive(true);
        this.ctrll.Movement.GetComponent<EnemyMovement>().decreaseSpeed(0.01f);
    }
}
