using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedSender : AutoMonobehaviour
{
    [SerializeField] protected int dame = 5;
    [SerializeField] protected int maxDame = 10;

    public virtual void Add(int dame)
    {
        this.dame = Mathf.Min(this.dame + dame, this.maxDame);
    }

    public virtual void Send(Transform obj)
    {
       //For overright
    }

    protected virtual void SendDame(DamagedReceiver dameToObj)
    {
        dameToObj.Deduct(this.dame);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        //For overright
    }
}
