using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyHolder : MonoBehaviour
{
    public EnergyInfo energyInfo;
    public UnityEvent<float> onEnergyChanged;
    public UnityEvent onEnergyEmpty;

    private float maxEnergy;
    private float inverseMaxEnergy;

    void Start()
    {
        maxEnergy = energyInfo.maxEnergy;
        inverseMaxEnergy = 1f / maxEnergy;
        _currentEnergy = energyInfo.maxEnergy;
    }

    public float CurrentEnergy {
        get => _currentEnergy;
        protected set {
            _currentEnergy = Mathf.Clamp(value, 0f, maxEnergy);
            onEnergyChanged.Invoke(_currentEnergy * inverseMaxEnergy);
            if (value <= 0f)
            {
                onEnergyEmpty.Invoke();
            }
        }
    }
    private float _currentEnergy;

    public void Increment(float quantity)
    {
        CurrentEnergy += quantity;
    }

    public void Decrement(float quantity)
    {
        CurrentEnergy -= quantity;
    }
}
