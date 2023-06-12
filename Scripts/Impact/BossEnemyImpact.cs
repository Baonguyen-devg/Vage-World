using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyImpact : EnemyImpact
{
    protected virtual void OnEnable()
    {
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("Shaking");
    }

    protected override void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.parent.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }
}
