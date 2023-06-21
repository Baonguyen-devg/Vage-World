using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public abstract class DamageSender : AutoMonobehaviour
    {
        [Header("Object's damage sender"), Space(10)]
        [SerializeField] protected int dame = 5;
        [SerializeField] protected int maximumDame = 10;

        public virtual void IncreaseDame(int dame) =>
            this.dame = Mathf.Min(this.dame + dame, this.maximumDame);

        public virtual void DecreaseDame(int dame) =>
            this.dame = Mathf.Max(this.dame - dame, 0);

        public abstract void Send(Transform obj);
    }
}