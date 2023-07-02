using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : AutoMonobehaviour
{
    [SerializeField] private List<Transform> listBehaviors;

    protected override void LoadComponent() => this.loadBehaviors();

    protected virtual void loadBehaviors()
    {
        if (this.listBehaviors.Count != 0) return;
        foreach (Transform behavior in transform)
            this.listBehaviors.Add(item: behavior);
    }

    public virtual Transform GetBehaviorByName(string name)
    {
        foreach (Transform behavior in this.listBehaviors)
            if (name.Equals(value: behavior.name)) return behavior;
        return null;
    }
}
