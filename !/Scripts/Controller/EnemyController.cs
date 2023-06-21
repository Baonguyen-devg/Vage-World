using Pathfinding;
using UnityEngine;
using DamageReceiver;
using DamageSender;
using Movement;

public class EnemyController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected EnemyMovement movement;
    [SerializeField] protected EnemyDamageSender damageSender;
    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    [SerializeField] protected EnemyHealthBar healthBar;
    [SerializeField] protected EnemyCloseCombatAttack closeCombat;
    private Transform posRoot;

    public EnemyMovement Movement => this.movement;
    public Transform Model => this.model;
    public EnemyDamageSender DamageSender => this.damageSender;
    public EnemyDamageReceiver DamageReceiver => this.damageReceiver;
    public EnemyHealthBar HealthBar => this.healthBar;
    public EnemyCloseCombatAttack CloseCombat => this.closeCombat;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDamagedSender();
        this.LoadDamagedReceiver();
        this.LoadHealthBar();
        this.LoadCloseCombat();
    }

    protected virtual void Start()
    {
        GameObject pos = new GameObject();
        pos.transform.position = transform.position;
        this.posRoot = pos.transform;
    }

    protected virtual void LoadDamagedReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.Find("DamageReceiver").GetComponent<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": Load DamageReceiver", gameObject);
    }

    protected virtual void LoadHealthBar()
    {
        if (this.healthBar != null) return;
        this.healthBar = transform.Find("HealthBar").GetComponentInChildren<EnemyHealthBar>();
        Debug.Log(transform.name + ": Load HealthBar", gameObject);
    }

    protected virtual void LoadDamagedSender()
    {
        if (this.damageSender != null || transform.Find("DamageSender") == null) return;
        this.damageSender = transform.Find("DamageSender").GetComponent<EnemyDamageSender>();
        Debug.Log(transform.name + ": Load DamageSender", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadCloseCombat()
    {
        if (this.closeCombat != null || transform.Find("CloseCombat") == null) return;
        this.closeCombat = transform.Find("CloseCombat").GetComponent<EnemyCloseCombatAttack>();
        Debug.Log(transform.name + ": Load CloseCombat", gameObject);
    }

    public virtual void DoAttack() =>
        gameObject.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").transform;

    public virtual void StopAttack() =>
         gameObject.GetComponent<AIDestinationSetter>().target = this.posRoot;
}
