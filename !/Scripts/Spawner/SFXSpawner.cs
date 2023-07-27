using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSpawner : Spawner
{
    [SerializeField] protected static SFXSpawner instance;
    public static SFXSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        SFXSpawner.instance = this;
    }

    public virtual void PlaySound(string soundName, string nameRegion)
    {
        Transform region = this.GetRegionByName(nameRegion);
        if (region == null) return;
  
        Transform obj = this.GetObjectByName(soundName, region);
        if (obj == null) return;

        Transform objSpawn = this.GetPoolObject(obj);
        objSpawn.gameObject.SetActive(true);
        objSpawn.SetParent(this.holder);
        objSpawn.GetComponent<AudioSource>().Play();
    }
}
