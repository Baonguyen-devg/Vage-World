using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : AutoMonobehaviour
{ 
    [SerializeField] protected ItemController controller;
    public ItemController Controller => this.controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemController();
    }

    protected virtual void LoadItemController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": Load ItemController", gameObject); ;
    }
    
    public virtual void OnMouseDown()
    {
        PlayerController player = transform.Find("Player").GetComponent<PlayerController>();
     

    }

    public virtual void OnMouseEnter()
    {
        this.controller.Frame.Find("Model").gameObject.SetActive(true);
    }

    public virtual void OnMouseExit()
    {
        this.controller.Frame.Find("Model").gameObject.SetActive(false);
    }
}
