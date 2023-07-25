using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullSpawnerPrefab : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> spacePrefabs;
    protected void LoadSpacePrefabs()
    {
        this.spacePrefabs.Clear();
        foreach (Transform prefab in transform)
            this.spacePrefabs.Add(item: prefab);
    }

    [SerializeField] protected BossDemonController controller;
    protected void LoadBossDemonController() =>
        this.controller = transform.parent?.GetComponent<BossDemonController>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossDemonController();
        this.LoadSpacePrefabs();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.controller.Movement.gameObject.SetActive(false);
        StartCoroutine(this.ContinueMove());

        foreach (Transform space in this.spacePrefabs)
            space.GetComponent<SpacePrefab>().Spawner("Fire_Skull");
    }

    protected virtual IEnumerator ContinueMove()
    {
        yield return new WaitForSeconds(1f);
        this.controller.Movement.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
