using System.Collections.Generic;
using UnityEngine;

public class ListPrefab : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listPrefabs;
    public List<Transform> ListPrefabs => this.listPrefabs;
    protected virtual void LoadPrefabs()
    {
        if (this.listPrefabs.Count != 0) return;
        foreach (Transform prefab in transform)
            this.listPrefabs.Add(item: prefab);
    }

    protected override void LoadComponent() => this.LoadPrefabs();

    public virtual Transform GetRandomPrefab() =>
        this.listPrefabs[Random.Range(minInclusive: 0, maxExclusive: this.listPrefabs.Count)];
}
