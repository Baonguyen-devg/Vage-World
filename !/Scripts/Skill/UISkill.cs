using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : AutoMonobehaviour
{
    [SerializeField] protected Transform skill;
    protected virtual void LoadSkillPrefab() =>
        this.skill ??= SkillController.Instance?.GetPrefabByName(gameObject.name);

    [SerializeField] protected Button buttomUpdate;
    protected virtual void LoadButtomUpdate() =>
        this.buttomUpdate ??= transform.Find("Update")?.Find("Button")?.GetComponent<Button>();

    [SerializeField] protected List<Image> listRender;
    protected virtual void LoadListRender()
    {
        if (this.listRender.Count != 0) return;
        Transform render = transform.Find(n: "MaterialFrame").Find(n: "NumberInfor");

        foreach (Transform objectRender in render)
            this.listRender.Add(item: objectRender.GetComponentInChildren<Image>());
    }

    [SerializeField] protected Image imageShader;
    protected virtual void LoadImageShader() =>
        this.imageShader ??= transform.Find("ImageSkillShader")?.GetComponent<Image>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkillPrefab();
        this.LoadButtomUpdate();
        this.LoadListRender();
        this.LoadImageShader();
    }

    protected virtual void LoadUIMaterial()
    {
        int index = 0;
        foreach (KeyValuePair<Transform, int> skillPrefab in this.skill.GetComponent<Skill>().ListRandomMaterial)
        {
            this.listRender[index++].sprite = transform.parent.GetComponent<UISkillController>().GetPrefabByName(_name: "Image" + skillPrefab.Key.name).sprite;
            this.listRender[index - 1].transform.parent.Find(n: "Number").GetComponent<Text>().text = skillPrefab.Value.ToString();
        }
    }

    protected virtual void Start() => Invoke(methodName: "LoadUIMaterial", time: 0.5f);

    protected virtual void Update()
    {
        if (transform.name == "Skill1")
            this.imageShader.fillAmount = (SkillController.Instance.TimeSkill1 - Time.time) / this.skill.GetComponent<Skill>().TimeDelay;

        if (transform.name == "Skill2")
            this.imageShader.fillAmount = (SkillController.Instance.TimeSkill2 - Time.time) / this.skill.GetComponent<Skill>().TimeDelay;

        if (transform.name == "Skill3")
            this.imageShader.fillAmount = (SkillController.Instance.TimeSkill3 - Time.time) / this.skill.GetComponent<Skill>().TimeDelay;

        if (this.CheckEnoughMaterial()) this.buttomUpdate.gameObject.SetActive(value: true);
        else this.buttomUpdate.gameObject.SetActive(value: false);
    }

    protected virtual bool CheckEnoughMaterial() =>
        (this.skill.GetComponent<Skill>().CheckEnough());
}
