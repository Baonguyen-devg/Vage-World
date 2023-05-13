using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected float addSpeed = 0.1f;
    [SerializeField] protected Vector2 movement;
    [SerializeField] protected PlayerController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody2D();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<PlayerController>();
        Debug.Log(transform.name + ": Load Player Controller", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigid2D != null) return;
        this.rigid2D = transform.parent.GetComponent<Rigidbody2D>();
        this.rigid2D.gravityScale = 0;
        this.rigid2D.freezeRotation = true;
    }

    protected virtual void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement.x < 0) this.controller.Model.transform.rotation = Quaternion.Euler(0, 180, 0);
        else this.controller.Model.transform.rotation = Quaternion.Euler(0, 0, 0);

        this.controller.Model.GetComponent<Animator>().SetFloat("Horizontal", movement.x);
        this.controller.Model.GetComponent<Animator>().SetFloat("Vertical", movement.y);
        this.controller.Model.GetComponent<Animator>().SetFloat("Speed", movement.magnitude);
    }

    protected override void Move()
    {
        base.Move();
        this.rigid2D.MovePosition(this.rigid2D.position + this.movement * this.speed * Time.fixedDeltaTime);
    }
}
