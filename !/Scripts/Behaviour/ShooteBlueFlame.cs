using System.Collections;
using UnityEngine;

public class ShooteBlueFlame : AutoMonobehaviour, IBehaviourSO
{
    private readonly int TRIGGER_DISAPPEAR = Animator.StringToHash("Disappear");
    private readonly int TRIGGER_APPEAR = Animator.StringToHash("Appear");
    private readonly int TRIGGER_ATTACK = Animator.StringToHash("Attack");

    [SerializeField] private Transform _boss;
    [SerializeField] private Animator _animatorBoss;
    [SerializeField] private Vector3 _distanceToTarget;

    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private float _timeDelay;

    private bool _canAttack = false;

    public void DoBehaviour()
    {
        if (!_canAttack) return;
        _animatorBoss.SetTrigger(TRIGGER_DISAPPEAR);
        Extension.StartDelayAction(this, 1f, () =>
        {
            _boss.position = TeleportPosition();
            _animatorBoss.SetTrigger(TRIGGER_APPEAR);

            Extension.StartDelayAction(this, 0.5f, () =>
            {
                SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_FIRE_EXPLOSION);
                _animatorBoss.SetTrigger(TRIGGER_ATTACK);
            });
        });
        _canAttack = false;
    }

    public void SetTargetFollow(Transform target)
    {
        _canAttack = false;
        _targetFollow = target;

        Extension.StartDelayAction(this, 0.2f, () => {
            _canAttack = true;
        });
    }

    protected Vector3 TeleportPosition() => _targetFollow.position + _distanceToTarget;
    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
}
