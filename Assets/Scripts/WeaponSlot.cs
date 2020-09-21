using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public WeaponInfo currentWeaponInfo;
    public SpriteRenderer spriteRenderer;
    public Sprite emptySlotSprite;
    public Transform crosshair;
    [Range(-180, 180)]
    public float minAngle = 0;
    [Range(-180, 180)]
    public float maxAngle = 0;
    public float angularSpeed = 4f;

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
        SetPlayerInteraction(false);
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
        crosshair.gameObject.SetActive(playerInteracting);
    }

    public void Fire()
    {
        Debug.Assert(AvailableForInteraction && havePlayerInteracting);
        GameObject projectile = GameObject.Instantiate(currentWeaponInfo.projectilePrefab, crosshair.position, crosshair.rotation);
    }

    public void Move(float horizontalAxis, float verticalAxis)
    {

    }
}
