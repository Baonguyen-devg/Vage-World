using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerPointSpawnMovement : PointSpawnMovement
    {
        protected override Vector2 GetPos() =>
            Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.parent.position;
    }
}