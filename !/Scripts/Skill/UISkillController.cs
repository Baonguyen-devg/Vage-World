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
        if (this.skillPrefab.Count != 0) return;

        foreach (Transform prefab in transform)
            this.skillPrefab.Add(item: prefab);
    }

    [SerializeField] protected List<Image> materialFramePrefab;
    protected virtual void LoadMaterialFramePrefab()
    {
        if (this.materialFramePrefab.Count != 0) return;
        Transform material = transform.Find(n: "MaterialFramePrefab");

        foreach (Transform prefab in material)
            this.materialFramePrefab.Add(item: prefab.GetComponent<Image>());
    }

    protected override void LoadComponent()
    {
        UISkillController.instance = this;
        base.LoadComponent();
        this.LoadSkillPrefab();
        this.LoadMaterialFramePrefab();
    }

    public virtual Image GetPrefabByName(string _name)
    {
        foreach (Image prefab in this.materialFramePrefab)
            if (_name == prefab.name) return prefab;
        return null;
    }
}
