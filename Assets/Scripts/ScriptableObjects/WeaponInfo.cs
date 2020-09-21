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
    }

    public WeaponInfo.Type type;
    public string displayName;
    public Sprite sprite;
    public GameObject projectilePrefab;
}
