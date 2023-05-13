using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateMapController : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> mapPrefabs;
    [SerializeField] protected List<Transform> mapRandoms;
    protected int[] arrayRandom;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMapPrefabs();
    }

    protected override void Awake()
    {
        int[] arrayRandom = new int[4];
        this.CreateListRandomMap();
        this.CreateLink();
    }

    protected virtual void CreateLink(Transform linkMap1, Transform linkMap2)
    {
        Portal outPortalMap1 = linkMap1.Find("OutPortal").Find("Impact").GetComponent<Portal>();
        Portal inPortalMap2 = linkMap2.Find("InPortal").Find("Impact").GetComponent<Portal>();
        
        outPortalMap1.ChangeGoal(inPortalMap2.transform.parent);
        inPortalMap2.ChangeGoal(outPortalMap1.transform.parent);
    }

    protected virtual void CreateLink()
    {
        for (int i = 0; i <= 3; i++)
            if (i == 3) this.CreateLink(this.mapRandoms[3].Find("Link"), this.mapRandoms[1].Find("Link"));
            else this.CreateLink(this.mapRandoms[i].Find("Link"), this.mapRandoms[i + 1].Find("Link"));
    }

    protected virtual void CreateArrayRandom()
    {
        int[] array = {0, 1, 2, 3};
        System.Random random = new System.Random();
        arrayRandom = array.OrderBy(element => random.Next()).ToArray();
    }

    protected virtual void CreateListRandomMap()
    {
        this.CreateArrayRandom();
        for (int i = 0; i <= 3; i++)
        {
            this.mapRandoms.Add(this.mapPrefabs[arrayRandom[i]]);
            this.mapPrefabs[arrayRandom[i]].transform.position += new Vector3(150 * i, 0, 0);
        }
    }

    protected virtual void LoadMapPrefabs()
    {
        if (this.mapPrefabs.Count != 0) return;

        foreach (Transform map in transform)
            this.mapPrefabs.Add(map);
    }
}
