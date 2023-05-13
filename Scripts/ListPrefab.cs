using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPrefab : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listPrefabs;
    public List<Transform> ListPrefabs => this.listPrefabs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        foreach (Transform prefab in transform)
            this.listPrefabs.Add(prefab);
    }
}
