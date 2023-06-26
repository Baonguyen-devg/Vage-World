using System.Collections;
using System.Collections.Generic;
using DamageSender;
using UnityEngine;

public class HealthPowerUpController : AutoMonobehaviour
{
    [SerializeField] protected HealPowerUPItemImpact impact;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImpact();
    }

    protected virtual void LoadImpact() =>
        this.impact ??= transform.Find("Impact").GetComponent<HealPowerUPItemImpact>();
}
