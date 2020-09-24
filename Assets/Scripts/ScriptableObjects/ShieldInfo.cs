using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldInfo", menuName = "ScriptableObjects/ShieldInfo")]
public class ShieldInfo : EnergyInfo
{
    public float rechangePerActivation;
    public float activationDelay = 1f;
}
