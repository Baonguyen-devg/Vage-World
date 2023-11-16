using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObjects/Prefabs")]
public class PrefabsSO : ScriptableObject
{
    [SerializeField] private List<Transform> prefabs = new List<Transform>();

    public virtual void AddPrefab(Transform _prefab)
    {
        if (HaveInPrefabs(_prefab)) return;
        prefabs.Add(_prefab);
    }
    
    public virtual void RemovePrefab(Transform _prefab)
    {
        if (!HaveInPrefabs(_prefab)) return;
        prefabs.Remove(_prefab);
    }
    
    public virtual bool HaveInPrefabs(Transform _prefab)
    {
        foreach (Transform prefab in prefabs)
            if (prefab.GetInstanceID().Equals(_prefab.GetInstanceID()))
                return true;
        return false;
    }

    public List<Transform> GetPrefabs() => prefabs;
}
