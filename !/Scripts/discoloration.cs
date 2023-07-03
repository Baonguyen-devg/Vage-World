using UnityEngine;

[RequireComponent(requiredComponent: typeof(BoxCollider2D))]
[RequireComponent(requiredComponent: typeof(Rigidbody2D))]
public class discoloration : AutoMonobehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider;
    protected virtual void LoadBoxCollider()
    {
        this.boxCollider ??= gameObject.GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
    }

    [SerializeField] protected Rigidbody2D rigidBody;
    protected virtual void LoadRigidbody2D()
    {
        this.rigidBody ??= gameObject.GetComponent<Rigidbody2D>();
        this.rigidBody.isKinematic = true;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider();
        this.LoadRigidbody2D();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null
            && collision.GetComponent<EnemyController>() == null) return;
        transform.parent.Find(n: "Model").GetComponent<SpriteRenderer>().color = new(r: 1f, g: 1f, b: 1f, a: 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null
           && collision.GetComponent<EnemyController>() == null) return;
        transform.parent.Find(n: "Model").GetComponent<SpriteRenderer>().color = new(r: 1f, g: 1f, b: 1f, a: 1f);
    }
}
