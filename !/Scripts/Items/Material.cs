using UnityEngine;

public class Material : AutoMonobehaviour
{
    [SerializeField] protected int maximumNumber = 100;
    [SerializeField] protected int _numberMaterial; 

    public virtual void Increase(int number) =>
        _numberMaterial = Mathf.Min(_numberMaterial + number, maximumNumber);

    public virtual void Decrease(int number) =>
        _numberMaterial = Mathf.Max(_numberMaterial - number, 0);

    public int GetNumber() => _numberMaterial;
}
