using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunBehaviour : StateMachineBehaviour
{
    private const float default_CountDown_Attack = 2f;
    [SerializeField] private float countDownAttack = default_CountDown_Attack;

    [SerializeField] private EnemyController controller;
    protected virtual void LoadController(Transform transform) =>
        this.controller = transform.parent?.GetComponent<EnemyController>();

    [SerializeField] private Transform player;
    protected virtual void LoadPlayer() =>
        this.player = GameObject.Find("Player")?.transform;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.LoadController(animator.transform);
        this.LoadPlayer();
        this.countDownAttack = default_CountDown_Attack;
        this.controller.Movement.gameObject.SetActive(true);
        this.controller.RandomlyMovement.gameObject.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.countDownAttack = this.countDownAttack - Time.deltaTime;

        if (this.countDownAttack <= 0 || this.CalculateDistanceToPlayer(animator.transform) <= 1) 
            animator.SetTrigger("Attack");
    }

    protected virtual float CalculateDistanceToPlayer(Transform target) =>
       Vector3.Distance(target.position, this.player.position);
}
