using UnityEngine;
using UnityEngine.UI;
using DamageReceiver;

public class HealthBar : AutoMonobehaviour
{
    [SerializeField] private PlayerDamageReceiver _playerDamageReceiver;
    [SerializeField] private Slider _slider;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        _playerDamageReceiver = GameObject.Find("Player").GetComponentInChildren<PlayerDamageReceiver>();
        _slider = GetComponentInParent<Slider>();
    }

    protected override void Awake()
    {
        base.Awake();
        _slider.maxValue = _playerDamageReceiver.GetMaximumHealth();
        PlayerDamageReceiver.PlayerReceiveDamageEvent += UpdateSlider;
        UpdateSlider();
    }

    private void UpdateSlider() =>
         _slider.value = _playerDamageReceiver.GetCurrentHealth();

    private void OnDisable() => PlayerDamageReceiver.PlayerReceiveDamageEvent -= UpdateSlider;
}
