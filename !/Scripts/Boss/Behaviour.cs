using UnityEngine;

public class Behaviour : AutoMonobehaviour
{
    [SerializeField] protected string nameTrigger = null;
    [SerializeField] protected EnemyController ctrll;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.loadEnemyController();
    }

    protected virtual void loadEnemyController()
    {
        if (this.ctrll != null) return;
        this.ctrll = transform.parent.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyController", gameObject);
    }

    protected virtual void OnEnable()
    {
        this.ctrll.Model.GetComponent<Animator>().SetTrigger(transform.name);
    }
}
