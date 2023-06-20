using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillController : AutoMonobehaviour
{
    [SerializeField] protected static UISkillController instance;
    [SerializeField] protected List<Transform> skillPrefab;

    [SerializeField] protected List<Image> materialFramePrefab;

    public static UISkillController Instance => instance;

    protected override void LoadComponent()
    {
        UISkillController.instance = this;
        base.LoadComponent();
        this.LoadSkillPrefab();
        this.LoadMaterialFramePrefab();
    }

    protected virtual void LoadMaterialFramePrefab()
    {
        if (this.materialFramePrefab.Count != 0) return;
        Transform material = transform.Find("MaterialFramePrefab");

        foreach (Transform prefab in material)
            this.materialFramePrefab.Add(prefab.GetComponent<Image>());
    }

    protected virtual void LoadSkillPrefab()
    {
        if (this.skillPrefab.Count != 0) return;

        foreach (Transform prefab in transform)
            this.skillPrefab.Add(prefab);
    }

    public virtual Image GetPrefabByName(string _name)
    {
        foreach (Image prefab in this.materialFramePrefab)
            if (_name == prefab.name) return prefab;
        return null;
    }
}
