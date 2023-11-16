using UnityEngine;

namespace DamageSender
{
    public abstract class DamageSender : AutoMonobehaviour
    {
        [Header("Object's damage sender"), Space(10)]
        [SerializeField] protected int dame = 0;
        [SerializeField] protected int maximumDame = 100;

        public virtual void IncreaseDame(int dame) => dame = Mathf.Min(dame + dame, maximumDame);
        public virtual void DecreaseDame(int dame) => dame = Mathf.Max(dame - dame, 0);

        public abstract void Send(Transform obj);
    }
}