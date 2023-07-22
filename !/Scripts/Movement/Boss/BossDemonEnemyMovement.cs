using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class BossDemonEnemyMovement : EnemyMovement
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected double distanceStop;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadPlayer();
        }

        protected virtual void LoadPlayer() =>
            this.player ??= GameObject.Find("Player").transform;

        protected override void Update()
        {
            if (Vector2.Distance(this.player.position, transform.parent.position) <= this.distanceStop) return;
            Vector3 direc = (this.player.position - transform.parent.position);
            direc.Normalize();
            this.SetDirectionFollow(direc);
            base.Update();
        }
    }
}