using UnityEngine;

public class BossEnemyImpact : EnemyImpact
{
    protected virtual void OnEnable() =>
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("Shaking");

    protected override void LoadController() =>
        this.controller = (this.controller != null) ? this.controller
            : transform.parent.parent.parent.GetComponent<EnemyController>();
}
