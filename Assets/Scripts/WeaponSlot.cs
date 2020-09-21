using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public WeaponInfo currentWeaponInfo;
    public SpriteRenderer spriteRenderer;
    public Sprite emptySlotSprite;

    public bool AvailableForInteraction => weaponType != WeaponInfo.Type.None;

    private bool havePlayerInteracting = false;
    private WeaponInfo.Type weaponType = WeaponInfo.Type.None;

    void Awake()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Start()
    {
        SetWeapon(currentWeaponInfo);
    }

    public void SetWeapon(WeaponInfo weaponInfo)
    {
        currentWeaponInfo = weaponInfo;
        weaponType = weaponInfo?.type ?? WeaponInfo.Type.None;
        spriteRenderer.sprite = weaponInfo?.sprite ?? emptySlotSprite;
    }

    public void SetPlayerInteraction(bool playerInteracting)
    {
        havePlayerInteracting = playerInteracting;
        Debug.Log($"Player is interacting: {playerInteracting}");
    }
}
