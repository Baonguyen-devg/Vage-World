using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : AutoMonobehaviour
{
    private static MaterialManager _instance;
    public static MaterialManager Instance => _instance;

    [SerializeField] private List<Material> _materials;
    private Material _material;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        if (_materials.Count != 0) _materials.Clear();
      
        foreach (Transform material in transform)
            _materials.Add(material.GetComponent<Material>());
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        MaterialManager._instance = this;
    }

    public virtual void IncreaseNumber(string nameMaterial, int number)
    {
        _material = FindMaterialWithName(nameMaterial);
        if (_material == null) return;

        _material.Increase(number);
        //UIMaterialManager.Instance.ChangeNumber(nameMaterial, _material.GetNumber());
    }

    public virtual void DecreaseNumber(string nameMaterial, int number)
    {
        _material = FindMaterialWithName(nameMaterial);
        if (_material == null) return;

        _material.Decrease(number);
        //UIMaterialManager.Instance.ChangeNumber(nameMaterial, _material.GetNumber());
    }

    protected virtual Material FindMaterialWithName(string nameMaterial)
    {
        foreach (Material material in _materials)
            if (material.name.Equals(nameMaterial)) return material;
        return null;
    }

    public virtual int GetNumberMaterial(string nameMaterial)
    {
        _material = FindMaterialWithName(nameMaterial);
        if (_material == null) return -1;

        return _material.GetNumber();
    }
}
