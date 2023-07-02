using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

[RequireComponent(requiredComponent: typeof(Rigidbody2D))]
[RequireComponent(requiredComponent: typeof(CircleCollider2D))]
public class LootMaterial : AutoMonobehaviour
{
    [SerializeField] public Transform itemToPickup;
    [SerializeField] private float distanceCanPick = 0.8f;
    [SerializeField] private List<Transform> itemsCanPick;

    public virtual void SetItemToPickup(Transform item) => this.itemToPickup = item;

    private void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.Space) && this.itemsCanPick.Count != 0) this.itemToPickup = this.itemsCanPick[0];
        if (this.itemToPickup == null) return;

        if (Vector3.Distance(a: transform.position, b: itemToPickup.transform.position) <= this.distanceCanPick)
        {
            this.itemToPickup.GetComponent<Touch>().Loot();
            this.SetItemToPickup(item: null);
            this.itemsCanPick.Remove(item: this.itemToPickup);
        }
        else
        {
            Vector2 pos = (itemToPickup.transform.position - transform.parent.position);
            pos.Normalize();
            transform.parent.Find(n: "Movement").GetComponent<PlayerMovement>().
                UpdateGetInputAxis(axisX: pos.x, axisY: pos.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!LayerMask.NameToLayer(layerName: "item").Equals(obj: collision.gameObject.layer)) return;
        this.itemsCanPick.Add(item: collision.transform);
        collision.GetComponent<Touch>().ChangeStatusFrameAndHaveTouchTo(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!LayerMask.NameToLayer(layerName: "item").Equals(obj: collision.gameObject.layer)) return;
        this.itemsCanPick.Remove(item: collision.transform);
        collision.GetComponent<Touch>().ChangeStatusFrameAndHaveTouchTo(false);
    }
}
