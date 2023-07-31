using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> behaviours;
    protected virtual void LoadBehaviours()
    {
        this.behaviours.Clear();
        foreach (Transform behaviour in transform)
            this.behaviours.Add(behaviour);
    }

    [SerializeField] protected int count = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBehaviours();
    }

    public virtual void DoBehaviour()
    {
        this.count = (this.count + 1) % this.behaviours.Count;
        foreach (Transform behaviour in this.behaviours)
            behaviour.gameObject.SetActive(false);

        this.behaviours[count].gameObject.SetActive(true);
    }
}
