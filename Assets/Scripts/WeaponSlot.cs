using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public WeaponInfo currentWeaponInfo;
    public SpriteRenderer spriteRenderer;
    public Sprite emptySlotSprite;
    public Crosshair crosshair;
    public RepeatedShooter repeatedShooter;
    public GameObject slotSelector;

    public bool AvailableForInteraction => weaponType != WeaponInfo.Type.None;

    private bool havePlayerInteracting = false;
    private WeaponInfo.Type weaponType = WeaponInfo.Type.None;

    void Awake()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (!crosshair)
        {
            crosshair = GetComponentInChildren<Crosshair>();
        }
        if (!repeatedShooter)
        {
            repeatedShooter = GetComponentInChildren<RepeatedShooter>();
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
        repeatedShooter.Shoot(currentWeaponInfo);
    }

    public void RotateCrosshair(float horizontalAxis)
    {
        crosshair.Rotate(horizontalAxis);
    }
}
