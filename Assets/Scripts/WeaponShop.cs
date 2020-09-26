using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    public WeaponShopItem[] shopItems;

    void Awake()
    {
        if (shopItems == null || shopItems.Length == 0)
        {
            shopItems = GetComponentsInChildren<WeaponShopItem>();
        }
    }

    void OnEnable()
    {
        shopItems[0].GetComponent<Button>().Select();
    }

    [ContextMenu("FindShopItems")]
    void FindShopItems()
    {
        shopItems = GetComponentsInChildren<WeaponShopItem>();
    }
}
