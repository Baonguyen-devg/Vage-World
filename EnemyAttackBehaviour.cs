using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : StateMachineBehaviour
{
    [SerializeField] private EnemyController controller;
    protected virtual void LoadController(Transform transform) =>
        this.controller = transform.parent?.GetComponent<EnemyController>();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.LoadController(animator.transform);
       /* this.controller.Movement.gameObject.SetActive(false);
       // this.controller.RandomlyMovement.gameObject.SetActive(false);
        this.controller.BehaviorManager.DoBehaviour();*/
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime < 1f) return;
        animator.SetTrigger("Run");
    }
}
