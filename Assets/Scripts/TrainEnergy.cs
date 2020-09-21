using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainEnergy : MonoBehaviour
{
    public TrainEnergyInfo energyInfo;
    public UnityEvent<float> onMaxEnergyChanged;
    public UnityEvent<float> onEnergyChanged;
    public UnityEvent onEnergyEmpty;

    public float CurrentEnergy {
        get => _currentEnergy;
        protected set {
            _currentEnergy = value;
            onEnergyChanged.Invoke(value);
        }
    }
    private float _currentEnergy;

    void Start()
    {
        onMaxEnergyChanged.Invoke(energyInfo.maxEnergy);
        CurrentEnergy = energyInfo.maxEnergy;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile;
        if (collider.TryGetComponent<Projectile>(out projectile))
        {
            if (projectile.faction == Projectile.Faction.Enemy)
            {
                CurrentEnergy -= projectile.weaponInfo.damage;
                if (_currentEnergy <= 0f)
                {
                    onEnergyEmpty.Invoke();
                }
                Destroy(projectile.gameObject);
            }
        }
    }
}
