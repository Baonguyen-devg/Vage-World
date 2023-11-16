using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillController : AutoMonobehaviour
{
    [SerializeField] protected static UISkillController instance;
    public static UISkillController Instance => instance;

    [SerializeField] protected List<Transform> skillPrefab;
    protected virtual void LoadSkillPrefab()
    {
        if (skillPrefab.Count != 0) return;

        foreach (Transform prefab in transform)
            skillPrefab.Add(prefab);
    }

    [SerializeField] protected List<Image> materialFramePrefab;
    protected virtual void LoadMaterialFramePrefab()
    {
        if (materialFramePrefab.Count != 0) return;
        Transform material = transform.Find("MaterialFramePrefab");

        foreach (Transform prefab in material)
            materialFramePrefab.Add(prefab.GetComponent<Image>());
    }

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSkillPrefab();
        LoadMaterialFramePrefab();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UISkillController.instance = this;
    }

    public virtual Image GetPrefabByName(string _name)
    {
        foreach (Image prefab in materialFramePrefab)
            if (_name == prefab.name) return prefab;
        return null;
    }
}
