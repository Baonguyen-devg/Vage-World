using UnityEngine;

namespace Movement
{
    internal class PlayerMovement : Movement
    {
        [Header("Player Movement"), Space(10)]
        [SerializeField] protected Rigidbody2D rigid2D;
        [SerializeField] protected Vector2 movement;

        [Header("Player Controller"), Space(10)]
        [SerializeField] protected PlayerController controller;
        [SerializeField] protected Animator animator;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadRigidbody2D();
            this.LoadController();
            this.LoadAnimator();
        }

        protected virtual void LoadController() =>
            this.controller ??= transform.parent.GetComponent<PlayerController>();

        protected virtual void LoadAnimator() =>
            this.animator ??= this.controller.Model.GetComponent<Animator>();

        protected virtual void LoadRigidbody2D()
        {
            this.rigid2D ??= transform.parent.GetComponent<Rigidbody2D>();
            (this.rigid2D.gravityScale, this.rigid2D.freezeRotation) = (0, true);
        }

        protected virtual void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            this.FlipLeft();
            this.SetAnimatorFLoats();
        }

        protected virtual void FlipLeft() =>
            this.controller.Model.transform.rotation =
                (movement.x < 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

        protected virtual void SetAnimatorFLoats()
        {
            this.animator.SetFloat("Horizontal", movement.x);
            this.animator.SetFloat("Vertical", movement.y);
            this.animator.SetFloat("Speed", movement.magnitude);
        }

        protected override void Move() =>
             this.rigid2D.MovePosition(this.rigid2D.position + this.movement * this.speed * Time.fixedDeltaTime);
    }
}