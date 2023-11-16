using System.Collections;
using UnityEngine;

public class EnemyCloseCombatAttack : AutoMonobehaviour
{
    private readonly int SLASH_LEFT_TRIGGER = Animator.StringToHash("SlashLeft");

    [SerializeField] protected EnemyController controller;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Animator animatorSword;
    [SerializeField] protected Transform target;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        controller = transform.parent.parent.GetComponent<EnemyController>();
        animator = controller.Model.GetComponent<Animator>();
        animatorSword = controller.transform.Find("Weapon").Find("Sword").GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
    }

    protected override void OnEnable()
    {
        animatorSword.SetTrigger(SLASH_LEFT_TRIGGER);
        StartCoroutine(SetRunAnimation());
    }

    protected virtual IEnumerator SetRunAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
