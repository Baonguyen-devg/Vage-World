using UnityEngine;
using DamageReceiver;

namespace DamageSender
{
    internal abstract class DamageSender : AutoMonobehaviour
    {
        [Header("Object's damage sender"), Space(10)]
        [SerializeField] protected int dame = 5;
        [SerializeField] protected int maximumDame = 10;

        protected virtual void IncreaseDame(int dame) =>
            this.dame = Mathf.Min(this.dame + dame, this.maximumDame);

        protected virtual void DecreaseDame(int dame) =>
            this.dame = Mathf.Max(this.dame - dame, 0);

        protected abstract void Send(Transform obj);
    }
}