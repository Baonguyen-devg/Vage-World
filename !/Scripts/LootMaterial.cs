using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

public class LootMaterial : AutoMonobehaviour
{
    public GameObject itemToPickup;
    [SerializeField] protected Touch itemTouch;

    public virtual void SetItemToPickup(GameObject item, Touch itemTouch)
    {
        this.itemToPickup = item;   
        this.itemTouch = itemTouch;
    }

    private void Update()
    {
        if (itemToPickup != null)
        {
            if (Vector3.Distance(transform.position, itemToPickup.transform.position) < 1f)
            {
                this.itemTouch.Loot();
                this.itemToPickup = null;
                this.itemTouch = null; 
            }
            else
            {
                Vector2 pos = (itemToPickup.transform.position - transform.parent.position);
                pos.Normalize();
                transform.parent.Find("Movement").GetComponent<PlayerMovement>().
                    UpdateGetInputAxis(pos.x, pos.y);
            }
        }

    }
}
