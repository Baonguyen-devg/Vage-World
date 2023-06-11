using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImpact : Impact
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PointSpawnEnemy>() == null) return;
        collision.GetComponent<PointSpawnEnemy>().RequestEnemiesAttack();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PointSpawnEnemy>() == null) return;
        collision.GetComponent<PointSpawnEnemy>().RequestEnemiesStopAttack();
    }


}
