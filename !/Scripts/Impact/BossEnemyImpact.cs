using UnityEngine;

public class BossEnemyImpact : EnemyImpact
{
    protected override void OnEnable() =>
        GameObject.Find(name: "Camera").GetComponent<Animator>().SetTrigger(name: "Shaking");

    protected override void LoadController() =>
        this.controller = (this.controller != null) ? this.controller
            : transform.parent.parent.parent.GetComponent<EnemyController>();
}
