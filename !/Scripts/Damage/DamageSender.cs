using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    public abstract class DamageSender : AutoMonobehaviour
    {
        [Header(header: "Object's damage sender"), Space(height: 10)]
        [SerializeField] protected int dame = 5;
        [SerializeField] protected int maximumDame = 10;

        public virtual void IncreaseDame(int dame) =>
            this.dame = Mathf.Min(a: this.dame + dame, b: this.maximumDame);

        public virtual void DecreaseDame(int dame) =>
            this.dame = Mathf.Max(a: this.dame - dame, b: 0);

        public abstract void Send(Transform obj);
    }
}