using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    public EnergyHolder energyHolder;
    public SpriteRenderer energyBarSpriteRenterer;
    
    void Awake()
    {
        if (!energyHolder)
        {
            energyHolder = GetComponent<EnergyHolder>();
        }
        if (!energyBarSpriteRenterer)
        {
            energyBarSpriteRenterer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    public void ResizeEnergyBar(float normalizedValue)
    {
        var size = energyBarSpriteRenterer.size;
        size.x = normalizedValue;
        energyBarSpriteRenterer.size = size;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
