using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectWeaponSlot : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public WeaponShop weaponShop;
    public WeaponSlot weaponSlot;

    public void OnSelect(BaseEventData data)
    {
        weaponSlot.slotSelector.gameObject.SetActive(true);
    }

    public void OnDeselect(BaseEventData data)
    {
        weaponSlot.slotSelector.gameObject.SetActive(false);
    }

    public void SlotChosen()
    {
        weaponShop.FinishPurchaseWeapon(weaponSlot);
    }

    void OnDisable()
    {
        weaponSlot.slotSelector.gameObject.SetActive(false);
    }
}
