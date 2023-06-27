using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyMovement : AutoMonobehaviour
{
    [SerializeField] private Vector3 directionFollow;

    public void SetDirectionFollow(Vector3 direction) => this.directionFollow = direction;
    private void Update() => this.Move(this.directionFollow);

    private void Move(Vector3 direction) =>
         transform.parent.position = Vector3.Lerp(transform.parent.position, transform.parent.position + direction, 0.01f);
}
