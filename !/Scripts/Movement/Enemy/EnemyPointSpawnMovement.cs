using UnityEngine;

namespace Movement
{
    public class EnemyPointSpawnMovement : PointSpawnMovement
    {
        [SerializeField] private Transform player;

        #region Load Component Methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            player = GameObject.Find("Player").transform;
        }
        #endregion

        protected virtual void Update() => RotationFollowPosition(GetPos().normalized);

        protected override Vector2 GetPos() =>
            player.position - transform.parent.parent.position;
    }
}