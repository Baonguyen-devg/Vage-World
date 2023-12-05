using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObjects/Prefabs")]
public class PrefabsSO : ScriptableObject
{
    [SerializeField] 
    private List<Transform> _prefabs = new List<Transform>();

    public virtual void AddPrefab(Transform _prefab)
    {
        if (HaveInPrefabs(_prefab)) return;
        _prefabs.Add(_prefab);
    }
    
    public virtual void RemovePrefab(Transform _prefab)
    {
        if (!HaveInPrefabs(_prefab)) return;
        _prefabs.Remove(_prefab);
    }
    
    public virtual bool HaveInPrefabs(Transform _prefab)
    {
        foreach (Transform prefab in _prefabs)
            if (prefab.GetInstanceID().Equals(_prefab.GetInstanceID()))
                return true;
        return false;
    }

    public List<Transform> GetPrefabs() => _prefabs;
}
