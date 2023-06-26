using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUPItemImpact : Impact
{
    [SerializeField] protected int healthPoint = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Equals("Player")) return;
        collision.GetComponent<PlayerController>().DamageReceiver.IncreaseHealth(this.healthPoint);
        transform.parent.gameObject.SetActive(false);
    }
}
