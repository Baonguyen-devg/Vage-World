using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterialManager : AutoMonobehaviour
{
    private static UIMaterialManager _instance;
    public static UIMaterialManager Instance => _instance;

    [SerializeField] private List<Text> _UIMaterials;
    private Text _numberOfMaterialUI;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        if (_UIMaterials.Count != 0) _UIMaterials.Clear();

        foreach (Transform material in transform)
            _UIMaterials.Add(material.Find("Number").GetComponent<Text>());
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        UIMaterialManager._instance = this;
    }

    public virtual void ChangeNumber(string nameUIMaterial, int number)
    {
        _numberOfMaterialUI = FindUIMaterialWithName(nameUIMaterial);
        if (_numberOfMaterialUI == null) return;

        _numberOfMaterialUI.text = number.ToString();
    }

    protected virtual Text FindUIMaterialWithName(string UImaterialText)
    {
        foreach (Text UImaterial in _UIMaterials)
            if (UImaterial.transform.parent.name.Equals(UImaterialText)) return UImaterial;
        return null;
    }
}
