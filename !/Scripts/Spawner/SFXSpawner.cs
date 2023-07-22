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

    public virtual void PlaySound(string soundName) =>
        this.GetObjectByName(soundName, this.GetRegionByName("Forest"))?.GetComponent<AudioSource>()?.Play();

}
