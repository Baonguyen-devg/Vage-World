using System.Collections;
using UnityEngine;

public class AutoMonobehaviour : MonoBehaviour
{
    protected virtual void Reset() => this.LoadComponentInReset();

    protected virtual void LoadComponentInReset()
    {
        this.LoadComponent();
        this.LoadComponentReset();
    }

    protected virtual void LoadComponentReset() { /* For Override */ }

    protected virtual void LoadComponent() { /* For Override */ }

    protected virtual void Awake()
    {
        this.LoadComponentInReset();
        this.LoadComponentInAwakeBefore();
        this.LoadComponentInAwakeAfter();
    }

    protected virtual void LoadComponentInAwakeBefore() { /* For Override */ }

    protected virtual void LoadComponentInAwakeAfter() { /* For Override */ }

    protected virtual void Start()
    {
        StartCoroutine(routine: LoadWaitForShortTime());
        StartCoroutine(routine: LoadWaitForMediumTime());
        StartCoroutine(routine: LoadWaitForLongTime());
    }

    protected virtual IEnumerator LoadWaitForShortTime()
    {
        yield return new WaitForSeconds(seconds: 0.5f);
        /* For Override */
    }

    protected virtual IEnumerator LoadWaitForMediumTime()
    {
        yield return new WaitForSeconds(seconds: 1f);
        /* For Override */
    }

    protected virtual IEnumerator LoadWaitForLongTime()
    {
        yield return new WaitForSeconds(seconds: 1.5f);
        /* For Override */
    }
}
