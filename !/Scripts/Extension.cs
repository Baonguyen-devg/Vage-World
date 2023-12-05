using System.Collections;
using UnityEngine;
using System;

public static class Extension
{
    public static void StartDelayAction(this MonoBehaviour mono, float waitTime, Action callback)
    {
        mono.StartCoroutine(CoroutineDelay(waitTime, callback));
    }
    
    public static IEnumerator CoroutineDelay(float waitTime, Action callback)
    {
        yield return new WaitForSeconds(waitTime);
        callback?.Invoke();
    }
}
