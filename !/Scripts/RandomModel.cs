using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomModel : AutoMonobehaviour
{
    [SerializeField] private List<Transform> _models;
    [SerializeField] private int _randomIndex;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        if (_models.Count != 0) _models.Clear();
        foreach (Transform model in transform)
            _models.Add(model);
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        _randomIndex = Mathf.Abs(gameObject.GetInstanceID()) % _models.Count;
        for (int i = 0; i < _models.Count; i++)
            if (_randomIndex != i) 
                _models[i].gameObject.SetActive(false);
    }
}
