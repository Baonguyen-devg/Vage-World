using System.Collections.Generic;
using UnityEngine;

public class Spawner : AutoMonobehaviour
{
    [Header("[ Scriptable Obejct ]"), Space(6)]
    [SerializeField] protected PrefabsSO prefabSO;
    [SerializeField] protected bool isNullScriptableObject;
    [SerializeField] protected bool isLogger;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjects;
    [SerializeField] protected Transform holder;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        prefabSO = Resources.Load<PrefabsSO>(GetPath());
        prefabs = prefabSO.GetPrefabs();
        holder = transform.Find("Holder");
    }

    protected override void Awake()
    {
        base.Awake();
        if (isNullScriptableObject && CheckNullScriptableObject())
        {
            if (isLogger) Debug.LogError($"Have errors when load scriptable in {name}", this);
            gameObject.SetActive(false);
        }
    }

    protected virtual string GetPath() => null;
    protected virtual bool CheckNullScriptableObject() => prefabSO == null;

    public virtual Transform Spawn(string nameObject)
    {
        Transform obj = GetObjectByName(nameObject);
        if (obj == null) return null;

        Transform objSpawn = GetPoolObject(obj);
        objSpawn.SetParent(holder);
        return objSpawn;
    }

    protected virtual Transform GetObjectByName(string nameObject)
    {
        foreach (Transform obj in prefabs)
            if (obj.name == nameObject) return obj;
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        poolObjects.Add(obj);
    }

    protected virtual Transform GetPoolObject(Transform obj)
    {
        foreach (Transform prefab in poolObjects)
            if (obj.name == prefab.name && !prefab.gameObject.activeSelf)
            {
                poolObjects.Remove(prefab);
                return prefab;
            }

        Transform newObject = Instantiate(obj);
        newObject.name = obj.name;
        return newObject;
    }

    public virtual string GetRandomPrefab()
    {
        int keyObject = Random.Range(0, prefabs.Count);
        return prefabs[keyObject].name;
    }
}
