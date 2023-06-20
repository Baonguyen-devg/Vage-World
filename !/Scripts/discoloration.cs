using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class discoloration : AutoMonobehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected Rigidbody2D rigidBody;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigidBody != null) return;
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();
        this.rigidBody.isKinematic = true;
        Debug.Log(transform.name + ": Load Rigidbody2D", gameObject);
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = gameObject.GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load BoxCollider", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null
            && collision.GetComponent<EnemyController>() == null) return;
        transform.parent.Find("Model").GetComponent<SpriteRenderer>().color = new(1f, 1f, 1f, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null
           && collision.GetComponent<EnemyController>() == null) return;
        transform.parent.Find("Model").GetComponent<SpriteRenderer>().color = new(1f, 1f, 1f, 1f);
    }
}
