using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyHolder : MonoBehaviour
{
    public EnergyInfo energyInfo;
    public UnityEvent<float> onEnergyChanged;
    public UnityEvent onEnergyEmpty;

    private float inverseMaxEnergy;

    void Start()
    {
        inverseMaxEnergy = 1f / energyInfo.maxEnergy;
        _currentEnergy = energyInfo.maxEnergy;
    }

    public float CurrentEnergy {
        get => _currentEnergy;
        set {
            _currentEnergy = value;
            onEnergyChanged.Invoke(value * inverseMaxEnergy);
            if (value <= 0f)
            {
                onEnergyEmpty.Invoke();
            }
        }
    }
    private float _currentEnergy;
}
