using UnityEngine;

public class HealthPowerUpController : AutoMonobehaviour
{
    [SerializeField] protected HealPowerUPItemImpact impact;
    protected virtual void LoadImpact() =>
        impact = transform.Find("Impact").GetComponent<HealPowerUPItemImpact>();

    protected override void LoadComponent() => LoadImpact();
    public HealPowerUPItemImpact Impact => impact;
}
