using UnityEngine;
using UnityEngine.UI;

public class HealthBar : AutoMonobehaviour
{
    [SerializeField] protected PlayerDamagedReceiver playerDamagedReceiver;
    [SerializeField] protected Slider slider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadSlider();
        this.slider.maxValue = this.playerDamagedReceiver.Health;
    }

    protected virtual void Update()
    {
        this.slider.value = this.playerDamagedReceiver.Health;
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponentInParent<Slider>();
        Debug.Log(transform.name + ": Load Slider", gameObject);
    }

    protected virtual void LoadPlayer()
    {
        if (this.playerDamagedReceiver != null) return;
        this.playerDamagedReceiver = GameObject.Find("Player").GetComponentInChildren<PlayerDamagedReceiver>();
        Debug.Log(transform.name + ": Load Player", gameObject);
    }


}
