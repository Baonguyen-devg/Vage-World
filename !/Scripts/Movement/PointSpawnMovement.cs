using UnityEngine;

public class PointSpawnMovement : Movement
{
    [SerializeField] protected float distance = 2;

    protected virtual void Update()
    {
        Vector2 pos = this.GetPos();
        pos.Normalize();
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;

        Vector3 newRota = new Vector3(0, 0, angle - 90);
        transform.parent.parent.rotation = Quaternion.Euler(newRota);
    }

    protected virtual Vector2 GetPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.parent.position;
    }
}
