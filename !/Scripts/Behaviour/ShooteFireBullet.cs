using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooteFireBullet : MonoBehaviour, IBehaviourSO
{
    [SerializeField] private Transform _pointSpawn;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] public float _timeDelay;

    private bool isShoote;

    public void DoBehaviour()
    {
        if (isShoote) return;
        isShoote = true;

        Transform bullet = BulletSpawner.Instance.Spawn(BulletSpawner.BULLET_DRAGONFLY);
        bullet.position = _pointSpawn.position;
        bullet.rotation = _pointSpawn.rotation;
        bullet.gameObject.SetActive(true);
    }

    public void SetTargetFollow(Transform target)
    {
        _targetFollow = target;
        isShoote = false;
    }

    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
}
