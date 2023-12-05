using UnityEngine;

namespace DamageSender
{
    public abstract class DamageSender : AutoMonobehaviour
    {
        [Header("Object's damage sender"), Space(10)]
        [SerializeField] protected int dame = 0;
        [SerializeField] protected int maximumDame = 200;

        public virtual void IncreaseDame(int _dame) => dame = Mathf.Min(dame + _dame, maximumDame);
        public virtual void DecreaseDame(int _dame) => dame = Mathf.Max(dame - _dame, 0);

        public abstract void Send(Transform obj);
    }
}