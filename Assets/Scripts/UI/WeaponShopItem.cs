using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShopItem : MonoBehaviour, ISelectHandler, ICancelHandler
{
    public ScoreInfo playerScoreInfo;
    public WeaponInfo weaponInfo;
    public WeaponShop weaponShop;
    public Button button;
    public Image image;
    public Text title;
    public FormattedText damageText;
    public FormattedText delayText;
    public FormattedText priceText;
    public string buyText = "BUY NOW!";
    public string cannotBuyText = "No money =/";

    void OnEnable()
    {
        SetWeaponInfo(weaponInfo);
    }

    public void SetWeaponInfo(WeaponInfo weaponInfo)
    {
        this.weaponInfo = weaponInfo;
        image.sprite = weaponInfo.sprite;
        title.text = weaponInfo.displayName;
        damageText.SetWith(weaponInfo.damage);
        delayText.SetWith(weaponInfo.repeatDelay);
        bool canBuy = playerScoreInfo.CanBuyWeapon(weaponInfo);
        priceText.SetWith(canBuy ? buyText : cannotBuyText, weaponInfo.scoreWorth);
        button.interactable = canBuy;
    }

    public void PurchaseWeapon()
    {
        weaponShop?.PurchaseWeaponItem(weaponInfo);
    }

    public void OnSelect(BaseEventData data)
    {
        weaponShop?.ItemSelected(this);
    }

    public void OnCancel(BaseEventData data)
    {
        // Didn't manage to get OnCancel working on WeaponShop, so just reroute it here
        weaponShop?.OnCancel(data);
    }
}
