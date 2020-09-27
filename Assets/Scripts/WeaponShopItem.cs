﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopItem : MonoBehaviour
{
    public ScoreInfo playerScoreInfo;
    public WeaponInfo weaponInfo;
    public WeaponShop weaponShop;
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
        image.sprite = weaponInfo.sprite;
        title.text = weaponInfo.displayName;
        damageText.SetWith(weaponInfo.damage);
        delayText.SetWith(weaponInfo.repeatDelay);
        priceText.SetWith(playerScoreInfo.score >= weaponInfo.scoreWorth ? buyText : cannotBuyText, weaponInfo.scoreWorth);
    }

    public void PurchaseWeapon()
    {
        weaponShop.PurchaseWeaponItem(weaponInfo);
    }
}
