using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDemonBehaviours : AutoMonobehaviour
{
    [SerializeField] protected Animator animatorBackgroundColor;
    protected virtual void LoadAnimatorBackgroundColor() =>
        this.animatorBackgroundColor = GameObject.Find("Camera")?.transform.Find("Main Camera")?.
            Find("Background_Color")?.GetComponent<Animator>();

    [SerializeField] protected List<Transform> behaviours;
    protected virtual void LoadBehaviours()
    {
        this.behaviours.Clear();
        foreach(Transform behaviour in transform)
            this.behaviours.Add(behaviour);
    }

    [SerializeField] protected double countTime, rateTime;
    [SerializeField] protected int count = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBehaviours();
        this.LoadAnimatorBackgroundColor();
    }

    protected virtual void Update()
    {
        this.countTime = this.countTime + Time.deltaTime;
        if (this.countTime < this.rateTime) return;

        this.countTime = 0;
        this.count = (this.count + 1) % this.behaviours.Count;
        this.DoBehaviour(count);
    }

    protected virtual void DoBehaviour(int count)
    {
        foreach (Transform behaviour in this.behaviours)
            behaviour.gameObject.SetActive(false);

        this.animatorBackgroundColor.SetTrigger("Black_Screen");
        this.behaviours[count].gameObject.SetActive(true);
    }
}
