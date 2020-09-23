using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseEnergyFromProjectile : MonoBehaviour
{
    public EnergyHolder energyHolder;
    public Projectile.Faction faction;

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
            Debug.Assert(faction != Projectile.Faction.None && projectile.faction != Projectile.Faction.None);
            if (projectile.faction != this.faction)
            {
                energyHolder.CurrentEnergy -= projectile.weaponInfo.damage;
                Destroy(projectile.gameObject);
            }
        }
    }
}
