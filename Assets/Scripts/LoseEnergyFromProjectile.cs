using UnityEngine;

public class LoseEnergyFromProjectile : MonoBehaviour
{
    public EnergyHolder energyHolder;
    public Faction faction;

    void Awake()
    {
        if (!energyHolder)
        {
            energyHolder = GetComponent<EnergyHolder>();
        }
        if (!faction)
        {
            faction = GetComponentInParent<Faction>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile;
        if (collider.TryGetComponent<Projectile>(out projectile))
        {
            if (projectile.faction.HostileTo(this.faction))
            {
                energyHolder.Decrement(projectile.weaponInfo.damage);
                if (projectile.destroyOnContact)
                {
                    Destroy(projectile.gameObject);
                }
            }
        }
    }
}
