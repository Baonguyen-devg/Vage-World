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
        rigid2D = GetComponent<Rigidbody2D>();
        colli2D = GetComponent<Collider2D>();
    }
}
