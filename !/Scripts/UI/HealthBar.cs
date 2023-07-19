using UnityEngine;
using UnityEngine.UI;
using DamageReceiver;

public class HealthBar : AutoMonobehaviour
{
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    protected virtual void LoadPlayer() =>
        this.playerDamageReceiver ??= GameObject.Find("Player")?.GetComponentInChildren<PlayerDamageReceiver>();

    [SerializeField] protected Slider slider;
    protected virtual void LoadSlider() =>
         this.slider ??= GetComponentInParent<Slider>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadSlider();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.slider.maxValue = this.playerDamageReceiver.CurrentHealth;
    }

    protected virtual void Update() =>
         this.slider.value = this.playerDamageReceiver.CurrentHealth;
}
