using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnersBossDemon : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> circlePrefabs;
    protected virtual void LoadCirclePrefabs()
    {
        this.circlePrefabs.Clear();
        foreach (Transform prefab in transform) 
            this.circlePrefabs.Add(prefab);
    }
    public List<Transform> CirclePrefabs => this.circlePrefabs;

    protected override void LoadComponent() => this.LoadCirclePrefabs();

    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (Transform circle in this.circlePrefabs)
            circle.gameObject.SetActive(true);
        StartCoroutine(this.DisActive());
    }

    protected virtual IEnumerator DisActive()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

    public virtual int GetIndexPrefab(Transform prefab)
    {
        foreach (Transform prefabCircle in this.circlePrefabs)
            if (prefab.name.Equals(prefabCircle.name))
                return this.circlePrefabs.IndexOf(prefab);
        return 0;
    }
}
