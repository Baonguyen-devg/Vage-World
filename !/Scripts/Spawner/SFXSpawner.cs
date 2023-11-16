using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSpawner : Spawner
{
    public static readonly string SOUND_COLLECT_MATERIAL = "Sound_Collect_Material";
    public static readonly string SOUND_RED_SCREEN = "Sound_Red_Screen";
    public static readonly string SOUND_SLASH_SWORD = "Sound_Slash_Sword";

    protected static SFXSpawner instance;
    public static SFXSpawner Instance => instance;

    protected override string GetPath() => "Prefabs/Prefabs_SFX";
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        SFXSpawner.instance = this;
    }

    public virtual void PlaySound(string soundName)
    {
        Transform obj = GetObjectByName(soundName);
        if (obj == null) return;

        Transform objSpawn = GetPoolObject(obj);
        objSpawn.gameObject.SetActive(true);
        objSpawn.SetParent(holder);
        objSpawn.GetComponent<AudioSource>().Play();
    }
}
