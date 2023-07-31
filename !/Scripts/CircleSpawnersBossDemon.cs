using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnersBossDemon : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> circlePrefabs;
    protected virtual void LoadCirclePrefabs()
    {
        this.circlePrefabs.Clear();
        foreach (Transform prefab in transform) 
            this.circlePrefabs.Add(prefab);
    }
    public List<Transform> CirclePrefabs => this.circlePrefabs;

    [SerializeField] protected BossDemonController controller;
    protected virtual void LoadController() =>
        this.controller = transform.parent?.parent?.GetComponent<BossDemonController>();

    [SerializeField] protected Animator animatorBoss;
    protected virtual void LoadAnimator() =>
        this.animatorBoss = transform.parent?.parent?.Find("Model")?.GetComponent<Animator>();

    [SerializeField] protected Animator animatorBackgroundColor;
    protected virtual void LoadAnimatorBackgroundColor() =>
        this.animatorBackgroundColor = GameObject.Find("Camera")?.transform.Find("Main Camera")?.
            Find("Background_Color")?.GetComponent<Animator>();

    protected override void LoadComponent()
    {
        this.LoadAnimator();
        this.LoadCirclePrefabs();
        this.LoadController();
        this.LoadAnimatorBackgroundColor();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.animatorBoss.SetTrigger("Breath");
        this.controller.Movement.gameObject.SetActive(false);
        this.animatorBackgroundColor.SetTrigger("Black_Screen");
        SFXSpawner.Instance.PlaySound("Sound_Boss_Demon_Roar", "Forest");
        StartCoroutine(this.Accumulation());
        StartCoroutine(this.DisActive());
    }

    protected virtual IEnumerator Accumulation()
    {
        yield return new WaitForSeconds(1.2f);
        foreach (Transform circle in this.circlePrefabs)
            circle.gameObject.SetActive(true);
        StartCoroutine(this.SetAnimationIdle());
    }

    protected virtual IEnumerator SetAnimationIdle()
    {
        yield return new WaitForSeconds(0.5f);
        this.controller.Movement.gameObject.SetActive(true);
        this.animatorBoss.SetTrigger("Idle");
    }

    protected virtual IEnumerator DisActive()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

    public virtual int GetIndexPrefab(Transform prefab)
    {
        foreach (Transform prefabCircle in this.circlePrefabs)
            if (prefab.name.Equals(prefabCircle.name))
                return this.circlePrefabs.IndexOf(prefab);
        return 0;
    }
}
