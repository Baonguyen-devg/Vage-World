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
            LoadPlayer();
        }

        protected override void LoadComponentInAwakeBefore()
        {
            base.LoadComponentInAwakeBefore();
            timeStart = timeStart_Default;
        }

        protected virtual void LoadPlayer() =>
            player ??= GameObject.Find("Player").transform;

        protected override void Update()
        {
            timeStart = timeStart - Time.deltaTime;
            if (timeStart > 0) return;
            if (Vector2.Distance(player.position, transform.parent.position) <= distanceStop) return;

            Vector3 direc = (player.position - transform.parent.position);
            direc.Normalize();
            SetDirectionFollow(direc);
            base.Update();
        }
    }
}