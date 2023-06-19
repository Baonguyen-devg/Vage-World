using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IdleBehaviour : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.GetComponent<AIPath>().enabled = false;
    }
}
