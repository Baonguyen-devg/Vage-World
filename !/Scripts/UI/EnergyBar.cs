using UnityEngine;
using UnityEngine.UI;
using DamageReceiver;

public class EnergyBar : AutoMonobehaviour
{
    [SerializeField] private PlayerEnergy _playerEnergy;
    [SerializeField] private Slider _slider;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        _playerEnergy = GameObject.Find("Player").GetComponentInChildren<PlayerEnergy>();
        _slider = GetComponentInParent<Slider>();
    }

    protected override void Start()
    {
        base.Start();
        _slider.maxValue = _playerEnergy.GetMaxEnergy();
        PlayerEnergy.PlayerEnergyEvent += UpdateSlider;
        UpdateSlider();
    }

    private void UpdateSlider() =>
         _slider.value = _playerEnergy.GetCurrentEnergy();

    private void OnDisable() => PlayerEnergy.PlayerEnergyEvent -= UpdateSlider;
}
