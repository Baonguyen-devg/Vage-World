using UnityEngine;

public class TestEnemyController : AutoMonobehaviour 
{
    [SerializeField] private TestEnemyMovement movement;
    public TestEnemyMovement Movement => this.movement;
    private void LoadRandomlyMovement() =>
        this.randomlyMovemet ??= transform.Find("DrirectionRandomlyMovement")?.GetComponent<DirectionRandomlyMovement>();

    [SerializeField] private DirectionRandomlyMovement randomlyMovemet;
    public DirectionRandomlyMovement RandomlyMovement => this.randomlyMovemet;
    private void LoadMovement() => 
        this.movement ??= transform.Find("Movement")?.GetComponent<TestEnemyMovement>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadRandomlyMovement();
    }
}
