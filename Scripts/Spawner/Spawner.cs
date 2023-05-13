using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listPrefab;
    [SerializeField] protected List<Transform> poolObjects;
    [SerializeField] protected Transform holder;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefab();
        this.LoadHolder();
    }

    protected virtual void LoadPrefab()
    {
        if (this.listPrefab.Count > 0) return;
        Transform prefabObj = transform.Find("Prefab");
        foreach (Transform prefab in prefabObj)
            this.listPrefab.Add(prefab);
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": Load Holder", gameObject);
    }

    public virtual Transform FindRegion(string nameRegion)
    {
        Transform region = this.GetRegionByName(nameRegion);
        if (region == null) return null;
        return region;
    }

    public virtual Transform SpawnInRegion(string nameObject, string nameRegion, Vector3 postion, Quaternion rotation)
    {
        Transform region = this.GetRegionByName(nameRegion);
        if (region == null)
        {
            Debug.LogError(nameRegion + ": Can find Region");
            return null;
        }

        Transform obj = this.GetObjectByName(nameObject, region);
        if (obj == null)
        {
            Debug.LogError(nameObject + ": Can find object.");
            return null;
        }

        Transform objSpawn = this.GetPoolObject(obj);
        objSpawn.SetPositionAndRotation(postion, rotation);
       
        objSpawn.gameObject.SetActive(true);
        objSpawn.SetParent(this.holder);
        return objSpawn;
    }

    protected virtual Transform GetObjectByName(string nameObject, Transform region)
    {
        foreach (Transform obj in region.GetComponent<ListPrefab>().ListPrefabs)
            if (obj.name == nameObject) return obj;
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        this.poolObjects.Add(obj);
    }

    protected virtual Transform GetPoolObject(Transform obj)
    {
        foreach(Transform prefab in this.poolObjects)
            if (obj.name == prefab.name)
            {
                this.poolObjects.Remove(prefab);
                return prefab;
            }

        Transform newObject = Instantiate(obj);
        newObject.name = obj.name;
        return newObject;
    }

    protected virtual Transform GetRegionByName(string name)
    {
        foreach (Transform prefab in this.listPrefab)
            if (name == prefab.name) return prefab;
        return null;
    }

    public virtual string GetRandomPrefab()
    {
        int keyRegion = Random.Range(0, this.listPrefab.Count);
        List<Transform> virtualList = this.listPrefab[keyRegion].GetComponent<ListPrefab>().ListPrefabs;
        
        int keyObject = Random.Range(0, virtualList.Count);
        return virtualList[keyObject].name;
    }
}
