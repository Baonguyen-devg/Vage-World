using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : AutoMonobehaviour
{
    [SerializeField] protected SkillController skillController;
    [SerializeField] protected UISkillController controller;

    [SerializeField] protected Button buttomUpdate;
    [SerializeField] protected List<Image> listRender;
    [SerializeField] protected Image imageShader;

    protected virtual void LoadSkillPrefab() => 
       skillController = SkillManager.GetInstance().GetPrefabByName(gameObject.name);

    protected virtual void LoadListRender()
    {
        listRender.Clear();
        Transform render = transform.Find("MaterialFrame").Find("NumberInfor");
        foreach (Transform objectRender in render)
            listRender.Add(objectRender.GetComponentInChildren<Image>());
    }

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller = transform.parent.GetComponent<UISkillController>();
        buttomUpdate ??= transform.Find("Update")?.Find("Button")?.GetComponent<Button>();

        LoadListRender();
        imageShader = transform.Find("ImageSkillShader")?.GetComponent<Image>();
    }

    protected virtual void LoadUIMaterial()
    {
        int index = 0;
        foreach (KeyValuePair<Transform, int> skillPrefab in skillController.listRandomItems)
        {
            listRender[index].sprite = controller.GetPrefabByName("Image" + skillPrefab.Key.name).sprite;
            listRender[index].transform.parent.GetComponentInChildren<Text>().text = skillPrefab.Value.ToString();
            index = Mathf.Min(index + 1, skillController.listRandomItems.Count);
        }
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        LoadSkillPrefab();

        if (!skillController.gameObject.activeSelf) gameObject.SetActive(false);
        else LoadUIMaterial();
    }

    protected virtual void Update()
    {
        imageShader.fillAmount = (skillController.GetTimeCounter() - Time.time) / skillController.GetTimeDelay();

        if (CheckEnoughMaterial()) buttomUpdate.gameObject.SetActive(true);
        else buttomUpdate.gameObject.SetActive(false);
    }

    protected virtual bool CheckEnoughMaterial() => skillController.CheckEnough();
}
