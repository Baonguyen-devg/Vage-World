using System.Collections.Generic;
using UnityEngine;

public class SkillManager : AutoMonobehaviour
{
    private static SkillManager instance;
    public static SkillManager GetInstance() {
        if (instance == null) instance = new SkillManager();
        return instance;
    }

    [SerializeField] protected List<SkillController> skillPrefab;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (skillPrefab.Count != 0) return;
        Transform skills = transform.Find("SkillPrefab");

        foreach (Transform prefab in skills)
            skillPrefab.Add(prefab.GetComponent<SkillController>());
    }

    public SkillController GetPrefabByName(string name)
    {
        foreach (SkillController prefab in skillPrefab)
            if (name.Equals(prefab.name)) return prefab;
        return null;
    }
}