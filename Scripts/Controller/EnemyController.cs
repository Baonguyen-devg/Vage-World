using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AutoMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected EnemyMovement movement;
    [SerializeField] protected SignalImpact impact;
    [SerializeField] protected EnemyDamagedSender damagedSender;
    [SerializeField] protected EnemyDamagedReceiver damagedReceiver;
    [SerializeField] protected EnemyHealthBar healthBar;
    [SerializeField] protected CloseCombatAttack closeCombat;

    public EnemyMovement Movement => this.movement;
    public SignalImpact Impact => this.impact;
    public Transform Model => this.model;
    public EnemyDamagedSender DamagedSender => this.damagedSender;
    public EnemyDamagedReceiver DamagedReceiver => this.damagedReceiver;
    public EnemyHealthBar HealthBar => this.healthBar;
    public CloseCombatAttack CloseCombat => this.closeCombat;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadMovement();
        this.LoadImpact();
        this.LoadDamagedSender();
        this.LoadDamagedReceiver();
        this.LoadHealthBar();
        this.LoadCloseCombat();
    }

    protected virtual void LoadDamagedReceiver()
    {
        if (this.damagedReceiver != null) return;
        this.damagedReceiver = transform.Find("DamagedReceiver").GetComponent<EnemyDamagedReceiver>();
        Debug.Log(transform.name + ": Load DamagedReceiver", gameObject);
    }

    protected virtual void LoadHealthBar()
    {
        if (this.healthBar != null) return;
        this.healthBar = transform.Find("HealthBar").GetComponentInChildren<EnemyHealthBar>();
        Debug.Log(transform.name + ": Load HealthBar", gameObject);
    }

    protected virtual void LoadDamagedSender()
    {
        if (this.damagedSender != null) return;
        this.damagedSender = transform.Find("DamagedSender").GetComponent<EnemyDamagedSender>();
        Debug.Log(transform.name + ": Load DamagedSender", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.Find("Movement").GetComponent<EnemyMovement>();
        Debug.Log(transform.name + ": Load EnemyMovement", gameObject);
    }

    protected virtual void LoadImpact()
    {
        if (this.impact != null) return;
        this.impact = transform.Find("SignalImpact").GetComponent<SignalImpact>();
        Debug.Log(transform.name + ": Load SignalImpact", gameObject);
    }

    protected virtual void LoadCloseCombat()
    {
        if (this.closeCombat != null) return;
        this.closeCombat = transform.Find("CloseCombat").GetComponent<CloseCombatAttack>();
        Debug.Log(transform.name + ": Loaf CloseCombat", gameObject);
    }
}
