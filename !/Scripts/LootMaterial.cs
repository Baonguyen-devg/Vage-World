using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class LootMaterial : AutoMonobehaviour
{
    [SerializeField] private Touch _itemToPickup;
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private float _distanceCanPick = 0.8f;
    [SerializeField] private List<Touch> _itemsCanPick = new List<Touch>();

    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
        _playerMovement = transform.parent.Find("Movement").GetComponent<PlayerMovement>();

    private void Update()
    {
        bool spacePress = Manager.InputManager.GetInstance().IsSpacePress();
        if (spacePress && _itemsCanPick.Count != 0) _itemToPickup = _itemsCanPick[0]; 

        if (_itemToPickup == null) return;
 
        if (IsPlayerCloseEnoughToPickup())
        {
            _itemToPickup.Loot();
            _itemsCanPick.Remove(_itemToPickup);
            SetItemToPickup(null);
        }
        else MoveTowardsItem();
    }

    private void MoveTowardsItem()
    {
        Vector2 pos = (_itemToPickup.transform.position - transform.parent.position).normalized;
        _playerMovement.UpdateGetInputAxis(pos.x, pos.y);
    }

    private bool IsPlayerCloseEnoughToPickup() =>
        Vector3.Distance(transform.parent.position, _itemToPickup.transform.position) <= _distanceCanPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Touch touch = GetTouchByCollision(collision);
        if (touch == null) return;

        _itemsCanPick.Add(touch);
        touch.ChangeStatusFrameAndHaveTouchTo(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Touch touch = GetTouchByCollision(collision);
        if (touch == null) return;

        _itemsCanPick.Remove(touch);
        touch.ChangeStatusFrameAndHaveTouchTo(false);
    }

    private Touch GetTouchByCollision(Collider2D collision)
    {
        if (!LayerMask.NameToLayer("item").Equals(collision.gameObject.layer)) return null;
        Touch touch = collision.GetComponent<Touch>();
        return touch;
    }

    public virtual void SetItemToPickup(Transform item) =>
        _itemToPickup = item?.GetComponent<Touch>();

    public virtual Touch GetItemToPickup() => _itemToPickup;
}
