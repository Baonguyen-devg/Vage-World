using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public abstract class DamageSender : AutoMonobehaviour
    {
        protected const int default_Maximum_Damage = 100;

        [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
        [SerializeField] protected LevelManagerSO levelManagerSO = default;
        protected virtual void LoadLevelManagerSO() =>
             this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

        [Header(header: "Object's damage sender"), Space(height: 10)]
        [SerializeField] protected int dame = 0;
        [SerializeField] protected int maximumDame = default_Maximum_Damage;

        protected override void LoadComponent() => this.LoadLevelManagerSO();

        public virtual void IncreaseDame(int dame) =>
            this.dame = Mathf.Min(a: this.dame + dame, b: this.maximumDame);

        public virtual void DecreaseDame(int dame) =>
            this.dame = Mathf.Max(a: this.dame - dame, b: 0);

        public abstract void Send(Transform obj);
    }
}