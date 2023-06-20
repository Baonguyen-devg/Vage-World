using UnityEngine;

public class Material : AutoMonobehaviour
{
    [SerializeField] protected NumberMaterial material;
    [SerializeField] protected int MaxNumber = 100;
    public NumberMaterial InforMaterial => this.material;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.material = new NumberMaterial(transform.name, 0);
    }

    public virtual int Increase(int number)
    {
        int Number = Mathf.Min(this.material.numberMaterial + number, 100);
        this.material.SetNumber(Number);
        return Number;
    }

    public virtual int Decrease(int number)
    {
        int Number = Mathf.Max(this.material.numberMaterial - number, 0);
        this.material.SetNumber(Mathf.Max(this.material.numberMaterial - number, 0));
        return Number;
    }
}
