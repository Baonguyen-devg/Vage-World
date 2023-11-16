using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullCloseCombatAttack : AutoMonobehaviour
{
    [SerializeField] protected EnemyController controller;
    [SerializeField] protected Animator animator;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller = transform.parent?.parent?.GetComponent<EnemyController>();
        animator = controller?.Model?.GetComponent<Animator>();
    }

    protected override void OnEnable()
    {
        StartCoroutine(SetRunAnimation());
    }

    protected virtual IEnumerator SetRunAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
