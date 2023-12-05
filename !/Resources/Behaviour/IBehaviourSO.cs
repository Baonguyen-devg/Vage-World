using UnityEngine;

public interface IBehaviourSO
{
    public abstract void DoBehaviour();
    public abstract float GetTimeDelay();
    public abstract bool IsFinished();
    public abstract void SetTargetFollow(Transform target);
}
