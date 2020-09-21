using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedShooter : MonoBehaviour
{
    public Transform projectileSpawnPoint;

    private float lastShotTime = 0f;

    public void Shoot(WeaponInfo weaponInfo)
    {
        if (Time.time > lastShotTime + weaponInfo.repeatDelay)
        {
            lastShotTime = Time.time;
            GameObject.Instantiate(weaponInfo.projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }
}
