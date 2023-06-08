using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPrefab : AutoMonobehaviour
{
    [SerializeField] private List<Transform> listAnimation;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListAnimation();
    }

    private void LoadListAnimation()
    {
        if (this.listAnimation.Count != 0) return;
        foreach(Transform prefab in transform)
            this.listAnimation.Add(prefab);
    }
}
