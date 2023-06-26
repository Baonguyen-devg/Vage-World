using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : AutoMonobehaviour 
{
    [SerializeField] private TestEnemyMovement movement;
    public TestEnemyMovement Movement => this.movement;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
    }

    private void LoadMovement() => 
        this.movement ??= transform.Find("Movement")?.GetComponent<TestEnemyMovement>();
}
