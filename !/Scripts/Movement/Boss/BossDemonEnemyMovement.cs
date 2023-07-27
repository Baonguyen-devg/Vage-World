using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class BossDemonEnemyMovement : EnemyMovement
    {
        private const float timeStart_Default = 1;

        [SerializeField] protected Transform player;
        [SerializeField] protected double distanceStop;
        [SerializeField] protected float timeStart = timeStart_Default;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadPlayer();
        }

        protected override void LoadComponentInAwakeBefore()
        {
            base.LoadComponentInAwakeBefore();
            this.timeStart = timeStart_Default;
        }

        protected virtual void LoadPlayer() =>
            this.player ??= GameObject.Find("Player").transform;

        protected override void Update()
        {
            this.timeStart = this.timeStart - Time.deltaTime;
            if (this.timeStart > 0) return;
            if (Vector2.Distance(this.player.position, transform.parent.position) <= this.distanceStop) return;

            Vector3 direc = (this.player.position - transform.parent.position);
            direc.Normalize();
            this.SetDirectionFollow(direc);
            base.Update();
        }
    }
}