using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : AutoMonobehaviour
{
    [SerializeField] private SkillController skillController;
    [SerializeField] private Button buttomUpdate;
    [SerializeField] private Image imageShader;

    private List<Image> renders = new List<Image>();
    private List<Text> texts = new List<Text>();

    private string prefabImageName;
    private Image prefabItemImage;

    #region Load Components Methods;
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        buttomUpdate = transform.Find("Update").Find("Button").GetComponent<Button>();
        imageShader = transform.Find("Shader").GetComponent<Image>();
        LoadRendersAndTexts();
    }

    private void LoadRendersAndTexts()
    {
        if (renders.Count != 0) renders.Clear();
        if (texts.Count != 0) texts.Clear();

        Transform materials = transform.Find("Materials");
        foreach (Transform material in materials)
        {
            renders.Add(material.GetComponentInChildren<Image>());
            texts.Add(material.GetComponentInChildren<Text>());
        }
    }

    private void LoadSkillPrefab() => 
       skillController = SkillManager.Instance.GetPrefabByName(gameObject.name);
    #endregion

    private void Update()
    {
        if (skillController == null) return;
        float rate = skillController.GetTimeCounter() / skillController.GetTimeDelay();
        imageShader.fillAmount = rate;

        if (CheckEnoughMaterial()) buttomUpdate.gameObject.SetActive(true);
        else buttomUpdate.gameObject.SetActive(false);
    }

    private void LoadUIMaterial()
    {
        int index = 0;
        foreach (var skillPrefab in skillController.listRandomItems)
        {
            SetItemImage(index, skillPrefab.Key.name);
            SetValueText(index, skillPrefab.Value.ToString());
            index = index + 1;
        }
    }

    private void SetValueText(int index, string valueString) => texts[index].text = valueString;

    private void SetItemImage(int index, string prefabName)
    {
        prefabImageName = StringBuilder_ImageText(prefabName);
        prefabItemImage = UISkillManger.Instance.GetPrefabByName(prefabImageName);
        renders[index].sprite = prefabItemImage.sprite;
    }

    private string StringBuilder_ImageText(string prefabName)
    {
        System.Text.StringBuilder text = new System.Text.StringBuilder()
            .Append("Image").Append(prefabName);
        return text.ToString();
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        LoadSkillPrefab();

        if (!skillController.gameObject.activeSelf) gameObject.SetActive(false);
        else LoadUIMaterial();
    }

    private bool CheckEnoughMaterial() => skillController.CheckEnough();
}
