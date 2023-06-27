using Pathfinding;
using UnityEngine;
using DamageReceiver;
using DamageSender;
using Movement;

public class EnemyController : AutoMonobehaviour
{
    //Model Component
    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model ??= transform.Find("Model");

    //Movement Component
    [SerializeField] protected EnemyMovement movement;
    public EnemyMovement Movement => this.movement;
    private void LoadMovement() =>
       this.movement ??= transform.Find("Movement")?.GetComponent<EnemyMovement>();

    //EnemyDamageSender Component
    [SerializeField] protected EnemyDamageSender damageSender;
    public EnemyDamageSender DamageSender => this.damageSender;
    protected virtual void LoadDamagedSender() =>
        this.damageSender ??= transform.Find("DamageSender")?.GetComponent<EnemyDamageSender>();

    //DamagedReceiver Component
    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver DamageReceiver => this.damageReceiver;
    protected virtual void LoadDamagedReceiver() =>
       this.damageReceiver ??= transform.Find("DamageReceiver")?.GetComponent<EnemyDamageReceiver>();

    //HealthBar Component
    [SerializeField] protected EnemyHealthBar healthBar;
    public EnemyHealthBar HealthBar => this.healthBar;
    protected virtual void LoadHealthBar() =>
        this.healthBar ??= transform.Find("HealthBar")?.GetComponentInChildren<EnemyHealthBar>();

    //EnemyCloseCombatAttack Component
    [SerializeField] protected EnemyCloseCombatAttack closeCombat;
    public EnemyCloseCombatAttack CloseCombat => this.closeCombat;
    protected virtual void LoadCloseCombat() =>
        this.closeCombat ??= transform.Find("CloseCombat")?.GetComponent<EnemyCloseCombatAttack>();

    //CreateRandomDirection Component
    [SerializeField] protected CreateRandomDirection randomlyMovement;
    public CreateRandomDirection RandomlyMovement => this.randomlyMovement;
    private void LoadRandomlyMovement() =>
        this.randomlyMovement ??= transform.Find("DirectionRandomlyMovement").GetComponent<CreateRandomDirection>();

    private Transform posRoot;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadMovement();
        this.LoadDamagedSender();
        this.LoadDamagedReceiver();
        this.LoadHealthBar();
        this.LoadCloseCombat();
        this.LoadRandomlyMovement();
    }

    protected virtual void Start()
    {
        GameObject pos = new GameObject();
        pos.transform.position = transform.position;
        this.posRoot = pos.transform;
    }

    public virtual void DoAttack()
    {
        this.randomlyMovement.SetTargetFollow(GameObject.Find("Player").transform);
        this.model.GetComponent<BehaviorManager>().GetBehaviorByName("Run").gameObject.SetActive(true);
        this.RandomlyMovement.gameObject.SetActive(true);
    }

    public virtual void StopAttack()
    {
        this.randomlyMovement.SetTargetFollow(posRoot);
    }
}
