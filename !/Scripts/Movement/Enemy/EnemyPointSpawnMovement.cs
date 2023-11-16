using UnityEngine;

namespace Movement
{
    public class EnemyPointSpawnMovement : PointSpawnMovement
    {
        [SerializeField] private Transform player;
        protected virtual void LoadPlayer() =>
            player ??= GameObject.Find("Player").transform;

        protected virtual void Update() =>
            RotationFollowPosition(GetPos().normalized);

        protected override void LoadComponent()
        {
            base.LoadComponent();
            LoadPlayer();
        }

        protected override Vector2 GetPos() =>
            player.position - transform.parent.parent.position;
    }
}