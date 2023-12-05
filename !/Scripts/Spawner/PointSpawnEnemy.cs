using System.Collections.Generic;
using UnityEngine;

public class PointSpawnEnemy : AutoMonobehaviour
{
    [SerializeField] private double _rateTimeAttack;
    
    private List<EnemyController> _listEnemy = new List<EnemyController>();
    private double _timeStopAttack;
    private bool _isAttack;

    public void Add(Transform enemy) => 
        _listEnemy.Add(enemy.GetComponent<EnemyController>());

    public void Update()
    {
        if (_isAttack) _timeStopAttack = Time.time + _rateTimeAttack;

        /*if (!_isAttack && Time.time >= _timeStopAttack)
            foreach (EnemyController enemy in _listEnemy)
                enemy.StopAttack();*/
    }

    public void RequestEnemiesAttack()
    {
        _isAttack = true;
        /*foreach (EnemyController enemy in _listEnemy)
            enemy.DoAttack();*/
    }

    public void RequestEnemiesStopAttack() => _isAttack = false;
}
