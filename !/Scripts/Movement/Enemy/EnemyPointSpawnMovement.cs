using UnityEngine;

namespace Movement
{
    internal class EnemyPointSpawnMovement : PointSpawnMovement
    {
        [SerializeField] private Transform player;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadPlayer();
        }

        protected virtual void LoadPlayer() =>
            this.player ??= GameObject.Find("Player").transform;

        protected override Vector2 GetPos() =>
            this.player.position - transform.parent.parent.position;
    }
}