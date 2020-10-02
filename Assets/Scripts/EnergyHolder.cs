using UnityEngine;
using UnityEngine.Events;

public class EnergyHolder : MonoBehaviour
{
    public EnergyInfo energyInfo;
    public bool invokeEmptyOnce = true;
    public UnityEvent<float> onEnergyChanged;
    public UnityEvent onEnergyEmpty;

    private float maxEnergy;
    private float inverseMaxEnergy;
    private bool emptyInvoked = false;

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
            if (value <= 0f && !(invokeEmptyOnce && emptyInvoked))
            {
                emptyInvoked = true;
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
