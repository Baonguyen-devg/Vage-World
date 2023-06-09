using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : Impact
{
    [SerializeField] protected EnemyController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }
    
    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.parent.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            this.SendDame(collision.transform);
            return;
        }
     /*   if (collision.transform.name != "Main Camera") return;

        this.controller.Movement.gameObject.SetActive(true);*/
    }
    
    protected virtual void SendDame(Transform obj)
    {
        this.controller.DamagedSender.Send(obj);
    }
}
