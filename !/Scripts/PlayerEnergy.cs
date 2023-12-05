using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : AutoMonobehaviour
{
    [Header("[ Player Energy Information]"), Space(6)]
    [SerializeField] private float _maxEnergy = 1000;
    [SerializeField] private float _timeDelayMax = 3f;
    [SerializeField] private float _rateIncrease = 2f;

    [SerializeField] private EventSO _LeftMousePressed;
    [SerializeField] private EventSO _PlayerEnergyChanged;

    private float _currentEnergy;
    private float _countTime;

    protected override void Awake()
    {
        base.Awake();
        _currentEnergy = _maxEnergy;
    }

    protected override void Start() => _LeftMousePressed.Subscribe(DecreaseEnergy);

    private void Update()
    {
        if (_countTime > 0)
        {
            _countTime = _countTime - Time.deltaTime;
            return;
        }
        IncreaseEnergy(_rateIncrease);
    }

    private void IncreaseEnergy(float energy)
    {
        _currentEnergy = Mathf.Min(_maxEnergy, _currentEnergy + energy);
        OnPlayerEnergyChanged();
    }

    private void DecreaseEnergy()
    {
        float mana = PlayerAttackBehaviours.GetInstance().GetMana();
        if (mana > _currentEnergy) return;

        bool canAttack = PlayerAttackBehaviours.GetInstance().RequestAttack();
        if (canAttack)
        {
            _currentEnergy = Mathf.Max(0, _currentEnergy - mana);
            OnPlayerEnergyChanged();
            if (mana != 0) SetTimeDelayMax();
        }
    }
    
    private void OnPlayerEnergyChanged() => _PlayerEnergyChanged?.Raise();
    public float GetMaxEnergy() => _maxEnergy;
    public float GetCurrentEnergy() => _currentEnergy;

    private void SetTimeDelayMax() => _countTime = _timeDelayMax;
    private void OnDisable() => _LeftMousePressed.UnSubscribe(DecreaseEnergy);
}
