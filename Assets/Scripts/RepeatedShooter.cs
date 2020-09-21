using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedShooter : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public Projectile.Faction faction;

    private float lastShotTime = 0f;

    public void Shoot(WeaponInfo weaponInfo)
    {
        Debug.Assert(faction != Projectile.Faction.None);
        if (Time.time > lastShotTime + weaponInfo.repeatDelay)
        {
            lastShotTime = Time.time;
            var projectile = Instantiate(weaponInfo.projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.weaponInfo = weaponInfo;
            projectile.faction = faction;
        }
    }
}
