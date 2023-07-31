using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImpact : Impact
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            AchievementController.Instance.IncreaseCoin(1);
            ItemSpawner.Instance.Despawn(transform.parent);
        }
    }
}
