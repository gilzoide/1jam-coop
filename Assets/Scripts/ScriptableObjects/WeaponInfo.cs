using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "ScriptableObjects/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    public enum Type
    {
        None,
        Machinegun,
        Grenade,
    }

    [Header("Attributes")]
    public WeaponInfo.Type type;
    public string displayName;
    public float repeatDelay = 0.2f;
    public float damage = 5f;
    public int scoreWorth;

    [Header("Runtime Components")]
    public Sprite sprite;
    public Projectile projectilePrefab;
}
