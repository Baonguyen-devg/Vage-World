using UnityEngine;

public abstract class Attack : AutoMonobehaviour
{
    [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
    [SerializeField] protected LevelManagerSO levelManagerSO = default;
    protected virtual void LoadLevelManagerSO() =>
         this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

    [SerializeField] protected float attackDelay;
    [SerializeField] protected float attackTimer;

    protected override void OnEnable() => this.LoadLevelManagerSO();

    protected virtual void Update()
    {
        if (this.CanAttack()) this.ToAttack();
    }

    public virtual void ToAttack() {   /*For Override */  }

    protected virtual bool CanAttack()
    {
        this.attackTimer = this.attackTimer + Time.deltaTime;
        if (this.attackTimer < this.attackDelay) return false;
        return true;
    }
}
