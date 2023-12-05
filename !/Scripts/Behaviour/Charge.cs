using UnityEngine;

public class Charge : MonoBehaviour, IBehaviourSO
{
    private readonly int READY_TRIGGER = Animator.StringToHash("Ready");

    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private float _speed;
    [SerializeField] public float _timeDelay;
    [SerializeField] protected Animator animatorSword;

    private bool isNearPlayer = false;
    private bool canAttack = false;

    public void DoBehaviour()
    {
        if (!canAttack) return;
        if (Vector2.Distance(_parent.position, _targetFollow.position) <= 0.5f)
        {
            isNearPlayer = true;
            return;
        }

        Vector3 direction = GetNormailzed(_parent.position, _targetFollow.position);
        _parent.position = Vector3.Lerp(_parent.position,
            _parent.position + direction, _speed);
    }

    private Vector3 GetNormailzed(Vector3 A, Vector3 B) => (B - A).normalized;

    public void SetTargetFollow(Transform target)
    {
        canAttack = false;
        isNearPlayer = false;
        _targetFollow = target;

        animatorSword.SetTrigger(READY_TRIGGER);
        Extension.StartDelayAction(this, 1f, () => {
            canAttack = true;
        });
    }

    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => isNearPlayer;
}
