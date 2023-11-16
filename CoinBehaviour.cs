using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : StateMachineBehaviour
{
    private const float default_Speed = 0.05f;
    private const float default_Speed_Pick = 0.2f;
    private const float default_Distance_Pick = 2f;

    [SerializeField] private Vector3 destinationPos;
    [SerializeField] private float distancePick = default_Distance_Pick;

    [SerializeField] private float speed = default_Speed;
    [SerializeField] private float speedPick = default_Speed_Pick;
    [SerializeField] private bool canPick = false;

    [SerializeField] private Transform player;
    protected virtual void LoadPlayer() =>
        this.player = GameObject.Find("Player")?.transform;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.LoadPlayer();
        float posXDestination = Random.Range(-1f, 1f);
        float posYDestination = Random.Range(-1f, 1f);
        this.destinationPos = animator.transform.parent.position + new Vector3(posXDestination, posYDestination, 0);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (this.canPick) this.CheckDistanceToPick(animator.transform);
        else this.CheckDestinationPos(animator.transform);
    }

    protected virtual void CheckDistanceToPick(Transform transform)
    {
        if (Vector3.Distance(transform.parent.position, this.player.position) > this.distancePick) return;
        transform.parent.position = Vector3.Lerp(transform.parent.position, this.player.position, this.speedPick);

        if (Vector3.Distance(transform.parent.position, this.player.position) <= 0.5f)
        {
            AchievementController.Instance.IncreaseCoin(1);
            SFXSpawner.Instance.PlaySound("Sound_Coin");
            ItemSpawner.Instance.Despawn(transform.parent);
        }
    }

    protected virtual void CheckDestinationPos(Transform transform)
    {
        if (Vector3.Distance(transform.parent.position, destinationPos) <= 0.1f) this.canPick = true;
        else transform.parent.position = Vector3.Lerp(transform.parent.position, this.destinationPos, this.speed);
    }
}
