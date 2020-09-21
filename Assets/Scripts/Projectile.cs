using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum Faction {
        None,
        Player,
        Enemy,
    }
    public WeaponInfo weaponInfo;
    public Faction faction;
}
