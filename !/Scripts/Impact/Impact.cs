using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Impact : AutoMonobehaviour
{
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected Collider2D colli2D;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider2D();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (this.colli2D != null) return;
        this.colli2D = GetComponent<Collider2D>();
        Debug.Log(transform.name + ": Load Collider2D", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigid2D != null) return;
        this.rigid2D = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": Load Rigidbody2D", gameObject);
    }


}
