using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class SwordEnemyPointAttack : PointSpawnMovement
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

        protected override void OnEnable()
        {
            base.OnEnable();
            RotationFollowPosition(GetPos().normalized);
        }

        protected override void RotationFollowPosition(Vector2 position)
        {
            float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
            Vector3 newRota = new Vector3(0, 0, angle - 90);
            transform.parent.localRotation = Quaternion.Euler(newRota);
        }

        protected override Vector2 GetPos() =>
            player.position - transform.parent.position;
    }
}