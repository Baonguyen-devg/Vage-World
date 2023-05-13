using UnityEngine;

public class DamagedReceiver : AutoMonobehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int healthMax = 10;
    [SerializeField] protected bool isDead = false;

    [SerializeField] protected GameObject deadFX;

    public int Health => this.health;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDeadFX();
        this.Reborn();
    }

    protected virtual void LoadDeadFX()
    {
        if (this.deadFX != null) return;
        this.deadFX = GameObject.Find("DeadFX");
        Debug.Log(transform.name + ": Load DeadFX", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.CheckDead();
    }

    public virtual bool IsDead()
    {
        return this.health == 0;
    }

    public virtual void Reborn()
    {
        this.isDead = false;
        this.health = this.healthMax;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;
        this.health = Mathf.Min(this.healthMax, this.health + add);
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;
        this.health = Mathf.Max(0, this.health - deduct);
        this.CheckDead();
    }

    protected virtual void CheckDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        //For overright
    }
}
