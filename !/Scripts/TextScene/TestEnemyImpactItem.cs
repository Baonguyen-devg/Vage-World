using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyImpactItem : AutoMonobehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.NameToLayer("Obstacle") != collision.gameObject.layer) return;
        Debug.Log("Bao");
        Vector3 avoidDirection = collision.transform.position;
        transform.parent.GetComponent<TestEnemyController>().RandomlyMovement.AddAnAvoidDirection(avoidDirection);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.NameToLayer("Obstacle") != collision.gameObject.layer) return;
        Vector3 avoidDirection = collision.transform.position;
        transform.parent.GetComponent<TestEnemyController>().RandomlyMovement.RemoveAnAvoidDirection(avoidDirection);
    }
}
