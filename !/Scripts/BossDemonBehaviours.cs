using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDemonBehaviours : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> behaviours;
    protected virtual void LoadBehaviours()
    {
        behaviours.Clear();
        foreach(Transform behaviour in transform)
            behaviours.Add(behaviour);
    }

    [SerializeField] protected double countTime, rateTime;
    [SerializeField] protected int count = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBehaviours();
    }

    protected virtual void Update()
    {
        countTime = countTime + Time.deltaTime;
        if (countTime < rateTime) return;

        countTime = 0;
        count = (count + 1) % behaviours.Count;
        DoBehaviour(count);
    }

    protected virtual void DoBehaviour(int count)
    {
        foreach (Transform behaviour in behaviours)
            behaviour.gameObject.SetActive(false);

        behaviours[count].gameObject.SetActive(true);
    }
}
