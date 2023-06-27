using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : AutoMonobehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private Rigidbody2D rigid2D;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigid2D();
    }

    private void LoadRigid2D() => this.rigid2D ??= transform.parent.GetComponent<Rigidbody2D>();

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(x, y);
        this.rigid2D.MovePosition(this.rigid2D.position + movement * this.speed * Time.deltaTime);
    }
}
