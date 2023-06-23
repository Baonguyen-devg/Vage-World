using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class GameBoyMovement : Movement
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected float distanceToPlayer = 3;
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
            pos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.player.position);
            this.direction = (pos - transform.parent.position);
            pos.Normalize();
            this.direction.Normalize();
     
            this.animator.SetFloat("Horizontal", pos.x);
            this.animator.SetFloat("Vertical", pos.y);
/*
            pos = this.player.position + pos * this.distanceToPlayer;
            transform.parent.position = Vector3.Lerp(transform.parent.position, pos, this.speed);*/
        }
    }
}