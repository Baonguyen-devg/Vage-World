using System.Collections.Generic;
using UnityEngine;

public class AnimationPrefab : AutoMonobehaviour
{
    [SerializeField] private List<Transform> listAnimation;
    private void LoadListAnimation()
    {
        if (this.listAnimation.Count != 0) return;
        foreach (Transform prefab in transform)
            this.listAnimation.Add(item: prefab);
    }

    protected override void LoadComponent() => this.LoadListAnimation();
}
