using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : AutoMonobehaviour
{
    public static readonly string FLOAT_BACKGROUND_VOLUME = "backgroundAudioVolume";
    public static readonly string FLOAT_SFX_VOLUME = "SFXAudioVolume";
    public static readonly string FLOAT_ALL_VOLUME = "AllAudioVolume";
    public static readonly string INT_UNLOCKED_LEVEL = "UnlockedLevel";
    public static readonly string INT_LEVEL = "Level";

    public static void SetFloatData(string nameData, float value) => PlayerPrefs.SetFloat(nameData, value);
    public static void StringData(string nameData, string value) => PlayerPrefs.SetString(nameData, value);
    public static void SetIntData(string nameData, int value) => PlayerPrefs.SetInt(nameData, value);

    public static float GetFloatData(string nameData) => PlayerPrefs.GetFloat(nameData);
    public static string GetStringData(string nameData) => PlayerPrefs.GetString(nameData);
    public static int GetIntData(string nameData) => PlayerPrefs.GetInt(nameData);

    public static bool HasData(string nameData) => PlayerPrefs.HasKey(nameData);
}
