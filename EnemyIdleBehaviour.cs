using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBehaviour : StateMachineBehaviour
{ 
    private const float default_Distance_Attack = 4;

    [SerializeField] private float distanceAttack = default_Distance_Attack;
    [SerializeField] private Transform player;
    protected virtual void LoadPlayer() =>
        this.player = GameObject.Find("Player")?.transform;

    [SerializeField] private EnemyController controller;
    protected virtual void LoadController(Transform transform) =>
        this.controller = transform.parent?.GetComponent<EnemyController>();

    [SerializeField] private Transform iconSignalAttack;
    protected virtual void LoadIconSignalAttack(Transform transform) =>
        this.iconSignalAttack = transform.Find("Signal_Attack")?.transform;

    private bool isRun = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.LoadPlayer();
        this.LoadIconSignalAttack(animator.transform);
        this.LoadController(animator.transform);
        //this.controller.Movement.gameObject.SetActive(false);
        //this.controller.RandomlyMovement.gameObject.SetActive(false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (this.CalculateDistanceToPlayer(animator.transform.parent) > this.distanceAttack) return;

        if (!this.isRun)
        {
            this.iconSignalAttack.gameObject.SetActive(true);
            GameManager.Instance.CoroutineStateMachineBehaviour(this.SetRun(animator));
            this.isRun = false;
        }
        GameManager.Instance.CoroutineStateMachineBehaviour(this.DisActiveSignalAttack());
    }

    private IEnumerator SetRun(Animator animator)
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Run");
    }

    private IEnumerator DisActiveSignalAttack()
    {
        yield return new WaitForSeconds(0.5f);
        this.iconSignalAttack.gameObject.SetActive(false);
    }

    protected virtual float CalculateDistanceToPlayer(Transform target) =>
        Vector3.Distance(target.position, this.player.position);
}
