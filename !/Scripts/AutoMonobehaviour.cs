using System.Collections;
using UnityEngine;

public class AutoMonobehaviour : MonoBehaviour
{
    protected virtual void Reset() => LoadComponent();

    protected virtual void LoadComponent() { /* For Override */ }

    protected virtual void Awake()
    {
        LoadComponent();
        LoadComponentInAwakeBefore();
        LoadComponentInAwakeAfter();
    }

    protected virtual void LoadComponentInAwakeBefore() { /* For Override */ }

    protected virtual void LoadComponentInAwakeAfter() { /* For Override */ }

    protected virtual void OnEnable() { /* For Override */ }

    protected virtual void Start()
    {
        StartCoroutine(routine: LoadWaitForShortTime());
        StartCoroutine(routine: LoadWaitForMediumTime());
        StartCoroutine(routine: LoadWaitForLongTime());
    }

    protected virtual IEnumerator LoadWaitForShortTime()
    {
        yield return new WaitForSeconds(seconds: 0.1f);
        /* For Override */
    }

    protected virtual IEnumerator LoadWaitForMediumTime()
    {
        yield return new WaitForSeconds(seconds: 0.2f);
        /* For Override */
    }

    protected virtual IEnumerator LoadWaitForLongTime()
    {
        yield return new WaitForSeconds(seconds: 0.3f);
        /* For Override */
    }
}
