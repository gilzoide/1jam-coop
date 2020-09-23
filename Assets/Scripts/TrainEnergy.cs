using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainEnergy : MonoBehaviour
{
    public EnergyHolder energyHolder;

    void Awake()
    {
        if (!energyHolder)
        {
            energyHolder = GetComponent<EnergyHolder>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile;
        if (collider.TryGetComponent<Projectile>(out projectile))
        {
            if (projectile.faction == Projectile.Faction.Enemy)
            {
                energyHolder.CurrentEnergy -= projectile.weaponInfo.damage;
                Destroy(projectile.gameObject);
            }
        }
    }
}
