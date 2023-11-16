using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBossDemonDespawnByTime : DespawnByTime
{
    public override void DespawnObject()
    {
        base.DespawnObject();
        transform.parent.gameObject.SetActive(false);
    }
}
