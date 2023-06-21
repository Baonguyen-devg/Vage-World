using UnityEngine;
using UnityEngine.UI;
using DamageReceiver;

public class HealthBar : AutoMonobehaviour
{
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    [SerializeField] protected Slider slider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadSlider();
        this.slider.maxValue = this.playerDamageReceiver.CurrentHealth;
    }

    protected virtual void Update()
    {
        this.slider.value = this.playerDamageReceiver.CurrentHealth;
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponentInParent<Slider>();
        Debug.Log(transform.name + ": Load Slider", gameObject);
    }

    protected virtual void LoadPlayer()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GameObject.Find("Player").GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + ": Load Player", gameObject);
    }


}
