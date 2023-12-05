using UnityEngine;

[RequireComponent(requiredComponent: typeof(BoxCollider2D))]
[RequireComponent(requiredComponent: typeof(Rigidbody2D))]
public class discoloration : AutoMonobehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider;
    [Range(0f, 1f), SerializeField] private float opacity = 1f;

    protected virtual void LoadBoxCollider()
    {
        boxCollider ??= gameObject.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    [SerializeField] protected Rigidbody2D rigidBody;
    protected virtual void LoadRigidbody2D()
    {
        rigidBody ??= gameObject.GetComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBoxCollider();
        LoadRigidbody2D();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null
            && collision.GetComponent<DamageReceiver.EnemyDamageReceiver>() == null) return;
        transform.parent.Find(n: "Model").GetComponent<SpriteRenderer>().color = new(r: 1f, g: 1f, b: 1f, opacity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null
           && collision.GetComponent<DamageReceiver.EnemyDamageReceiver>() == null) return;
        transform.parent.Find(n: "Model").GetComponent<SpriteRenderer>().color = new(r: 1f, g: 1f, b: 1f, a: 1f);
    }
}
