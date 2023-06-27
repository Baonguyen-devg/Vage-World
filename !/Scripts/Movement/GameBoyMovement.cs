using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class GameBoyMovement : Movement
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected float distanceToPlayer = 1;
        [SerializeField] protected Animator animator;

        [SerializeField] protected Vector3 pos;
        [SerializeField] protected Vector3 direction;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadPlayer();
            this.LoadAnimator();
        }

        protected virtual void LoadAnimator() =>
            this.animator ??= GameObject.Find("GameBoy").transform.Find("Model").GetComponent<Animator>();

        protected virtual void LoadPlayer() =>
            this.player ??= GameObject.Find("Player").transform;

        protected override void Move()
        {
            if (Vector2.Distance(transform.parent.position, this.player.position) <= distanceToPlayer) return;
            pos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.player.position);
            this.direction = (this.player.position - transform.parent.position);
            pos.Normalize();
            this.direction.Normalize();
     
            this.animator.SetFloat("Horizontal", direction.x);
            this.animator.SetFloat("Vertical", direction.y);

            Vector3 position = transform.parent.position + this.direction;
            transform.parent.position = Vector3.Lerp(transform.parent.position, position, this.speed);
        }
    }
}