using UnityEngine;

namespace Movement
{
    public class EnemyPointSpawnMovement : PointSpawnMovement
    {
        [SerializeField] private Transform player;
        protected virtual void LoadPlayer() =>
            this.player ??= GameObject.Find("Player").transform;

        protected virtual void Update() =>
            this.RotationFollowPosition(this.GetPos().normalized);

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadPlayer();
        }

        protected override Vector2 GetPos() =>
            this.player.position - transform.parent.parent.position;
    }
}