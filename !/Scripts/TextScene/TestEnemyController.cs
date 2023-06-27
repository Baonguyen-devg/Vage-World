using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : AutoMonobehaviour 
{
    [SerializeField] private TestEnemyMovement movement;
    public TestEnemyMovement Movement => this.movement;

    [SerializeField] private DirectionRandomlyMovement randomlyMovemet;
    public DirectionRandomlyMovement RandomlyMovement => this.randomlyMovemet;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadRandomlyMovement();
    }

    private void LoadRandomlyMovement() =>
        this.randomlyMovemet ??= transform.Find("DrirectionRandomlyMovement").GetComponent<DirectionRandomlyMovement>();

    private void LoadMovement() => 
        this.movement ??= transform.Find("Movement")?.GetComponent<TestEnemyMovement>();
}
