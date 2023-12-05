using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehavioursController : AutoMonobehaviour
{
    [SerializeField] private Transform signal;
    [SerializeField] private Transform targetFollow;
    [SerializeField] private EnemyController controller;

    private float timeDelay;
    private Queue<IBehaviourSO> behaviourQueue = new Queue<IBehaviourSO>();
    private IBehaviourSO behaviourPresent;
    private bool isStarted;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();

        if (behaviourQueue.Count != 0) behaviourQueue.Clear();
        foreach (Transform behaviour in transform)
            behaviourQueue.Enqueue(behaviour.GetComponent<IBehaviourSO>());
    }
    #endregion

    public void SetTargetFollow(Transform targetPosition)
    {
        if (isStarted) return;

        signal?.gameObject.SetActive(true);
        Extension.StartDelayAction(this, 0.5f, () =>
        {
            signal?.gameObject.SetActive(false);
            targetFollow = targetPosition;
            ChangeBehaviour();
            isStarted = true;
        });
    }

    private void ChangeBehaviour()
    {
        behaviourPresent = behaviourQueue.Dequeue();
        behaviourQueue.Enqueue(behaviourPresent);
        timeDelay = behaviourPresent.GetTimeDelay();
        behaviourPresent.SetTargetFollow(targetFollow);
    }

    protected void Update()
    {
        if (!isStarted || !GameManager.Instance.IsGamePlaying()) return;
        if (!behaviourPresent.IsFinished() && timeDelay - Time.deltaTime >= 0)
        {
            timeDelay = timeDelay - Time.deltaTime;
            behaviourPresent.DoBehaviour();
        }
        else ChangeBehaviour();
    }

    public void SetDirectionFollow(Transform direction) => targetFollow = direction;
}
