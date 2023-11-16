public abstract class Despawn : AutoMonobehaviour
{
    protected virtual void Update()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }

    public virtual void DespawnObject() { /* For override */ }

    protected abstract bool CanDespawn();
}
