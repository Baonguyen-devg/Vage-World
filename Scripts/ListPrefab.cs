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
        if (this.listPrefabs.Count != 0) return;
        foreach (Transform prefab in transform)
            this.listPrefabs.Add(prefab);
    }

    public virtual Transform GetRandomPrefab()
    {
        return this.listPrefabs[Random.Range(0, this.listPrefabs.Count)];
    }
}
