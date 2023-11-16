using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : AutoMonobehaviour
{
    [Header("[ Player Energy Information]"), Space(6)]
    [SerializeField] private float maxEnergy = 1000;
    [SerializeField] private float timeDelayMax = 3f;
    [SerializeField] private float rateIncrease = 2f;

    [SerializeField] private float currentEnergy;
    private float countTime;

    public static event System.Action PlayerEnergyEvent;

    protected override void Awake()
    {
        base.Awake();
        currentEnergy = maxEnergy;
    }

    protected override void Start() => Manager.InputManager.LeftMousePressEvent += DecreaseEnergy;

    private void Update()
    {
        if (countTime > 0)
        {
            countTime = countTime - Time.deltaTime;
            return;
        }
        IncreaseEnergy(rateIncrease);
    }

    private void IncreaseEnergy(float energy) =>
        currentEnergy = Mathf.Min(maxEnergy, currentEnergy + energy);

    private void DecreaseEnergy()
    {
        float mana = PlayerAttackBehaviours.GetInstance().GetMana();
        if (mana > currentEnergy) return;

        bool canAttack = PlayerAttackBehaviours.GetInstance().RequestAttack();
        if (canAttack)
        {
            currentEnergy = Mathf.Max(0, currentEnergy - mana);
            PlayerEnergyEvent?.Invoke();
            SetTimeDelayMax();
        }
    }
    
    public float GetMaxEnergy() => maxEnergy;
    public float GetCurrentEnergy() => currentEnergy;

    private void SetTimeDelayMax() => countTime = timeDelayMax;
    private void OnDisable() => Manager.InputManager.LeftMousePressEvent -= DecreaseEnergy;
}
