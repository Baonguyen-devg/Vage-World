using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : AutoMonobehaviour
{
    [SerializeField] private Animator animator;
    protected virtual void LoadAnimator() =>
        this.animator = GetComponent<Animator>();

    protected override void LoadComponent() => this.LoadAnimator();

    public virtual void CloseTutorialUI()
    {
        this.animator.SetTrigger("Close");
        StartCoroutine(this.DisActive());
    }

    protected virtual IEnumerator DisActive()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
