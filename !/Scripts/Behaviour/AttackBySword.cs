using UnityEngine;

public class AttackBySword : MonoBehaviour, IBehaviourSO
{
    private readonly int SLASH_LEFT_TRIGGER = Animator.StringToHash("SlashLeft");
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] public float _timeDelay;

    [SerializeField] protected Animator animatorSword;
    private bool isSword;

    public void DoBehaviour()
    {
        if (isSword) return;
        animatorSword.SetTrigger(SLASH_LEFT_TRIGGER);
        isSword = true;
    }

    public void SetTargetFollow(Transform target)
    {
        _targetFollow = target;
        isSword = false;
    }

    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
}
