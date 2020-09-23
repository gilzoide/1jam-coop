using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyHolder : MonoBehaviour
{
    public EnergyInfo energyInfo;
    public UnityEvent<float> onMaxEnergyChanged;
    public UnityEvent<float> onEnergyChanged;
    public UnityEvent onEnergyEmpty;

    void Start()
    {
        _currentEnergy = energyInfo.maxEnergy;
        onMaxEnergyChanged.Invoke(_currentEnergy);
    }

    public float CurrentEnergy {
        get => _currentEnergy;
        set {
            _currentEnergy = value;
            onEnergyChanged.Invoke(value);
            if (value <= 0f)
            {
                onEnergyEmpty.Invoke();
            }
        }
    }
    private float _currentEnergy;
}
