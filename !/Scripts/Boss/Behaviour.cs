using UnityEngine;

public class Behaviour : AutoMonobehaviour
{
    [SerializeField] protected string nameTrigger = null;
    [SerializeField] protected EnemyController ctrll;
    protected virtual void loadEnemyController() =>
        this.ctrll ??= transform?.parent?.parent?.GetComponent<EnemyController>();

    protected override void LoadComponent() => this.loadEnemyController();

    protected virtual void OnEnable() =>
        this.ctrll.Model.GetComponent<Animator>().SetTrigger(name: transform.name);
}
