using UnityEngine;

public class RepeatedShooter : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public Faction faction;

    private float lastShotTime = 0f;

    void Awake()
    {
        if (!faction)
        {
            faction = GetComponentInParent<Faction>();
        }
    }

    public void Shoot(WeaponInfo weaponInfo)
    {
        if (Time.time > lastShotTime + weaponInfo.repeatDelay)
        {
            lastShotTime = Time.time;
            var projectile = Instantiate(weaponInfo.projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.weaponInfo = weaponInfo;
            projectile.faction = faction;
        }
    }
}
