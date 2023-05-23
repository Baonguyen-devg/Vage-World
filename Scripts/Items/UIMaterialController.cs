using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterialController : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listUIMaterial;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListUIMaterial();
    }

    protected virtual void LoadListUIMaterial()
    {
        if (this.listUIMaterial.Count != 0) return;

        foreach (Transform material in transform)
            this.listUIMaterial.Add(material);
    }

    public virtual void ChangeNumber(string nameUIMaterial, int number)
    {
        Transform UIMaterial = this.FindUIMaterialWithName(nameUIMaterial);
        if (UIMaterial == null)
        {
            Debug.Log("Can't find the UIMaterial");
            return;
        }

        UIMaterial.Find("Number").GetComponent<Text>().text = number.ToString();
    } 

    protected virtual Transform FindUIMaterialWithName(string _UImaterial)
    {
        foreach (Transform UImaterial in this.listUIMaterial)
            if (UImaterial.name == _UImaterial) return UImaterial;
        return null;
    }
}
