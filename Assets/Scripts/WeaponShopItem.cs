using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopItem : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public Image image;
    public Text title;
    public FormattedText damageText;
    public FormattedText delayText;
    public FormattedText priceText;

    void Start()
    {
        SetWeaponInfo(weaponInfo);
    }

    public void SetWeaponInfo(WeaponInfo weaponInfo)
    {
        image.sprite = weaponInfo.sprite;
        title.text = weaponInfo.displayName;
        damageText.SetWith(weaponInfo.damage);
        delayText.SetWith(weaponInfo.repeatDelay);
        priceText.SetWith(weaponInfo.scoreWorth);
    }
}
