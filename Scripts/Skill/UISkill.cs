using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill: AutoMonobehaviour
{
    [SerializeField] protected Transform skill;
    [SerializeField] protected Button buttomUpdate;
    [SerializeField] protected List<Image> listRender;
    [SerializeField] protected Image imageShader;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkillPrefab();
        this.LoadButtomUpdate();
        this.LoadListRender();
        this.LoadImageShader();
    }

    protected virtual void LoadImageShader()
    {
        if (this.imageShader != null) return;
        this.imageShader = transform.Find("ImageSkillShader").GetComponent<Image>();
        Debug.Log(transform.name + ": Load ImageSkillShader", gameObject);
    }

    protected virtual void LoadListRender()
    {
        if (this.listRender.Count != 0) return;
        Transform render = transform.Find("MaterialFrame").Find("NumberInfor");

        foreach (Transform objectRender in render)
            this.listRender.Add(objectRender.GetComponentInChildren<Image>());
    }

    protected virtual void Start()
    {
        Invoke("LoadUIMaterial", 1f);
    }

    protected virtual void LoadUIMaterial()
    {
        int index = 0;
        foreach (KeyValuePair<Transform, int> skillPrefab in this.skill.GetComponent<Skill>().ListRandomMaterial)
        {
            this.listRender[index++].sprite = transform.parent.GetComponent<UISkillController>().GetPrefabByName("Image" + skillPrefab.Key.name).sprite;
            this.listRender[index - 1].transform.parent.Find("Number").GetComponent<Text>().text = skillPrefab.Value.ToString();
        }
    }

    protected virtual void Update()
    {
        if (transform.name == "Skill1") 
            this.imageShader.fillAmount = (SkillController.Instance.TimeSkill1 - Time.time) / this.skill.GetComponent<Skill>().TimeDelay;
        
        if (transform.name == "Skill2")
            this.imageShader.fillAmount = (SkillController.Instance.TimeSkill2 - Time.time) / this.skill.GetComponent<Skill>().TimeDelay;
       
        if (transform.name == "Skill3") 
            this.imageShader.fillAmount = (SkillController.Instance.TimeSkill3 - Time.time) / this.skill.GetComponent<Skill>().TimeDelay;

        if (this.CheckEnoughMaterial()) this.buttomUpdate.gameObject.SetActive(true);
        else this.buttomUpdate.gameObject.SetActive(false);
    }

    protected virtual bool CheckEnoughMaterial()
    {
        if (this.skill.GetComponent<Skill>().CheckEnough()) return true;
        return false;
    }

    protected virtual void LoadButtomUpdate()
    {
        if (this.buttomUpdate != null) return;
        this.buttomUpdate = transform.Find("Update").Find("Button").GetComponent<Button>();
        Debug.Log(transform.name + ": Load Buttom Update", gameObject);
    }

    protected virtual void LoadSkillPrefab()
    {
        if (this.skill != null) return;
        this.skill = SkillController.Instance.GetPrefabByName(gameObject.name);
        Debug.Log(transform.name + ": Load SkillPrefab", gameObject);
    }
}
