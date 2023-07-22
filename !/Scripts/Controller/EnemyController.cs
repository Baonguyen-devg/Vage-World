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
        this.randomlyMovement ??= transform.Find("DirectionRandomlyMovement")?.GetComponent<CreateRandomDirection>();

    private Transform posRoot;
    [SerializeField] private bool nearRoot;

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

    private void Update() => this.NearPosRoot();

    private void NearPosRoot()
    {
        if (this.nearRoot == false) return;
        if (Vector2.Distance(a: transform.position, b: this.posRoot.position) <= 0.5f)
        {
            this.nearRoot = false;
            this.randomlyMovement.gameObject.SetActive(value: false);
            this.model.GetComponent<BehaviorManager>().GetBehaviorByName(name: "Idle").gameObject.SetActive(value: true);
        }
    }

    protected override void LoadComponentInAwakeBefore()
    {
        GameObject pos = new GameObject();
        pos.transform.position = transform.position;
        this.posRoot = pos.transform;
        this.posRoot.SetParent(p: GameObject.Find(name: "HolderGameObject").transform);
    }

    public virtual void DoAttack()
    {
        this.randomlyMovement.gameObject.SetActive(value: true);
        this.randomlyMovement.SetTargetFollow(target: GameObject.Find(name: "Player").transform);
        this.movement.gameObject.SetActive(true);

        this.model.GetComponent<Animator>().SetTrigger("Run");
        this.nearRoot = false;
    }

    public virtual void StopAttack()
    {
        this.nearRoot = true;
        this.randomlyMovement.gameObject.SetActive(value: true);
        this.randomlyMovement.SetTargetFollow(target: posRoot);
        this.movement.gameObject.SetActive(true);
    }

    public virtual void Stand()
    {
        this.movement.gameObject.SetActive(false);
        this.randomlyMovement.gameObject.SetActive(false);
    }
}
