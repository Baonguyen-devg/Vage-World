using System.Collections.Generic;
using UnityEngine;

public class MaterialController : AutoMonobehaviour
{
    [SerializeField] protected static MaterialController instance;
    [SerializeField] protected List<Transform> listMaterial;
    [SerializeField] protected UIMaterialController MaterialUI;

    public static MaterialController Instance => instance;

    protected override void LoadComponent()
    {
        MaterialController.instance = this;
        base.LoadComponent();
        this.LoadMaterial();
        this.LoadMaterialUI();
    }

    protected virtual void LoadMaterialUI() =>
        this.MaterialUI = (this.MaterialUI != null) ? this.MaterialUI
            : GameObject.Find("Canvas").transform.Find("Panel").Find("BoxItems").GetComponent<UIMaterialController>();


    protected virtual void LoadMaterial()
    {
        if (this.listMaterial.Count != 0) return;
        Transform materials = transform.Find("Materials");

        foreach (Transform material in materials)
            this.listMaterial.Add(material);
    }

    public virtual void IncreaseNumber(string nameMaterial, int number)
    {
        Transform material = this.FindMaterialWithName(nameMaterial);
        if (material == null)
        {
            Debug.Log("Can find the Material");
            return;
        }

        int num = material.GetComponent<Material>().Increase(number);
        this.MaterialUI.ChangeNumber(nameMaterial, num);
    }

    public virtual void DecreaseNumber(string nameMaterial, int number)
    {
        Transform material = this.FindMaterialWithName(nameMaterial);
        if (material == null)
        {
            Debug.Log("Can find the Material");
            return;
        }

        int num = material.GetComponent<Material>().Decrease(number);
        this.MaterialUI.ChangeNumber(nameMaterial, num);
    }

    protected virtual Transform FindMaterialWithName(string nameMaterial)
    {
        foreach (Transform material in this.listMaterial)
            if (material.name == nameMaterial) return material;
        return null;
    }

    public virtual int GetNumberMaterial(string nameMaterial)
    {
        Transform material = this.FindMaterialWithName(nameMaterial);
        if (material == null)
        {
            Debug.Log("Can't find Material");
            return -1;
        }

        return material.GetComponent<Material>().InforMaterial.numberMaterial;
    }
}
