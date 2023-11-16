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
    [SerializeField] protected CreateRandomDirection randomlyMovement;
    [SerializeField] protected BehaviorManager behaviorManager;

    private Transform posRoot;
    [SerializeField] private bool nearRoot;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        model = transform.Find("Model");
        movement ??= transform.Find("Movement")?.GetComponent<EnemyMovement>();
        damageSender ??= transform.Find("DamageSender")?.GetComponent<EnemyDamageSender>();
        damageReceiver ??= transform.Find("DamageReceiver")?.GetComponent<EnemyDamageReceiver>();
        healthBar ??= transform.Find("HealthBar")?.GetComponentInChildren<EnemyHealthBar>();
        randomlyMovement ??= transform.Find("DirectionRandomlyMovement")?.GetComponent<CreateRandomDirection>();
        behaviorManager ??= transform.Find("Behaviours")?.GetComponent<BehaviorManager>();
    }

    private void Update() => NearPosRoot();

    private void NearPosRoot()
    {
       /* if ( .nearRoot == false) return;
        if (Vector2.Distance(a: transform.position, b: .posRoot.position) <= 0.5f)
        {
            nearRoot = false;
            randomlyMovement.gameObject.SetActive(value: false);
            model.GetComponent<BehaviorManager>().GetBehaviorByName(name: "Idle").gameObject.SetActive(value: true);
        }*/
    }

    protected override void LoadComponentInAwakeBefore()
    {
        GameObject pos = new GameObject();
        pos.transform.position = transform.position;
        posRoot = pos.transform;
        posRoot.SetParent(GameObject.Find("HolderGameObject").transform);
    }

    public virtual void DoAttack()
    {
        randomlyMovement.gameObject.SetActive(true);
        randomlyMovement.SetTargetFollow(GameObject.Find("Player").transform);
        nearRoot = false;
    }

    public virtual void StopAttack()
    {
        nearRoot = true;
        randomlyMovement.gameObject.SetActive(true);
        randomlyMovement.SetTargetFollow(posRoot);
    }

    public virtual void Stand() => randomlyMovement.gameObject.SetActive(false);

    public Transform Model => model;
    public EnemyMovement Movement => movement;
    public EnemyDamageSender DamageSender => damageSender;
    public EnemyDamageReceiver DamageReceiver => damageReceiver;
    public EnemyHealthBar HealthBar => healthBar;
    public CreateRandomDirection RandomlyMovement => randomlyMovement;
    public BehaviorManager BehaviorManager => behaviorManager;
}
