using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillManger : AutoMonobehaviour
{
    protected static UISkillManger instance;
    public static UISkillManger Instance => instance;

    [Header("[ Scriptable Obejct ]"), Space(6)]
    [SerializeField] protected PrefabsSO prefabSO;
    [SerializeField] protected bool isNullScriptableObject;
    [SerializeField] protected bool isLogger;

    [SerializeField] protected List<Image> itemImages;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        prefabSO = Resources.Load<PrefabsSO>(GetPath());
     
        if (isNullScriptableObject && CheckNullScriptableObject())
        {
            if (isLogger) Debug.LogError($"Have errors when load scriptable in {name}", this);
            gameObject.SetActive(false);
            return;
        }

        if (itemImages.Count != 0) itemImages.Clear();
        foreach (Transform prefab in prefabSO.GetPrefabs())
            itemImages.Add(prefab.GetComponent<Image>());
    }

    private string GetPath() => "Prefabs/Prefabs_Material_Image";
    protected virtual bool CheckNullScriptableObject() => prefabSO == null;
    #endregion

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UISkillManger.instance = this;
    }

    public virtual Image GetPrefabByName(string namePrefab)
    {
        foreach (Image prefab in itemImages)
            if (namePrefab.Equals(prefab.name)) return prefab;
        return null;
    }
}
