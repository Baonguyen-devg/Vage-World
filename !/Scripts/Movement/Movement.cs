using UnityEngine;

namespace Movement
{
    public abstract class Movement : AutoMonobehaviour
    {
        protected const float default_Speed = 0.02f;
        protected const float default_Maximum_Speed = 1;
        protected const float default_Minimum_Speed = 0.01f;    

        [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
        [SerializeField] protected LevelManagerSO levelManagerSO = default;
        protected virtual void LoadLevelManagerSO() =>
             this.levelManagerSO ??= Resources.Load<LevelManagerSO>(path: "Level/EasyLevel");

        [SerializeField] protected float speed = default_Speed;
        [SerializeField] protected float maximumSpeed = default_Maximum_Speed;
        [SerializeField] protected float minimumSpeed = default_Minimum_Speed;

        [SerializeField] protected bool isMovingFast = false;

        protected override void LoadComponent() => this.LoadLevelManagerSO();
      
        protected virtual void Update() => this.Move();

        public virtual void IncreaseSpeed(float speed) =>
            this.speed = Mathf.Min(a: this.maximumSpeed, b: this.speed + speed); 

        public virtual void DecreaseSpeed(float speed) =>
            this.speed = Mathf.Max(a: this.minimumSpeed, b: this.speed - speed);

        protected abstract void Move();
    }
}