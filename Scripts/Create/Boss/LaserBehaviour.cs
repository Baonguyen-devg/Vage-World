using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : Behaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ctrll.Movement.gameObject.SetActive(false);
    }
}