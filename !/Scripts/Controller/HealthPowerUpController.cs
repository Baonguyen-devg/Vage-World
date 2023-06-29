using UnityEngine;

public class HealthPowerUpController : AutoMonobehaviour
{
    [SerializeField] protected HealPowerUPItemImpact impact;
    public HealPowerUPItemImpact Impact => this.impact;
    protected virtual void LoadImpact() =>
        this.impact ??= transform.Find("Impact").GetComponent<HealPowerUPItemImpact>();

    protected override void LoadComponent() => this.LoadImpact();
}
