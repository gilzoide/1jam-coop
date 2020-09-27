using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour, ICancelHandler
{
    public ScoreInfo playerScoreInfo;
    public GameObject weaponsView;
    public GameObject slotSelectionView;
    public WeaponShopItem[] shopItems;
    public SelectWeaponSlot[] slotSelectionItems;
    public UnityEvent onEnabled;
    public UnityEvent onDisabled;


    private WeaponInfo weaponBeingPurchased;

    void Awake()
    {
        if (shopItems == null || shopItems.Length == 0)
        {
            shopItems = GetComponentsInChildren<WeaponShopItem>(true);
        }
        if (slotSelectionItems == null || slotSelectionItems.Length == 0)
        {
            slotSelectionItems = GetComponentsInChildren<SelectWeaponSlot>(true);
        }
    }

    public void PurchaseWeaponItem(WeaponInfo weaponInfo)
    {
        if (playerScoreInfo.score >= weaponInfo.scoreWorth)
        {
            weaponBeingPurchased = weaponInfo;
            ShowSelectSlot();
        }
        else
        {
            // TODO: feedback de falta dinheiro
            Debug.LogError("TODO: feedback de falta dinheiro");
        }
    }

    public void FinishPurchaseWeapon(WeaponSlot weaponSlot)
    {
        Debug.Assert(playerScoreInfo.score >= weaponBeingPurchased.scoreWorth);
        playerScoreInfo.Decrement(weaponBeingPurchased.scoreWorth);
        weaponSlot.SetWeapon(weaponBeingPurchased);
        weaponBeingPurchased = null;
        ShowSelectWeapon();
    }

    void ShowSelectWeapon()
    {
        weaponsView.SetActive(true);
        slotSelectionView.SetActive(false);
        shopItems[0].GetComponent<Button>().Select();
    }

    void ShowSelectSlot()
    {
        weaponsView.SetActive(false);
        slotSelectionView.SetActive(true);
        slotSelectionItems[0].GetComponent<Button>().Select();
    }

    public void OnCancel(BaseEventData data)
    {
        if (weaponBeingPurchased == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            weaponBeingPurchased = null;
            ShowSelectWeapon();
        }
    }

    void OnEnable()
    {
        ShowSelectWeapon();
        onEnabled.Invoke();
    }

    void OnDisable()
    {
        weaponBeingPurchased = null;
        onDisabled.Invoke();
    }

    [ContextMenu("FindAllItems")]
    void FindAllItems()
    {
        shopItems = GetComponentsInChildren<WeaponShopItem>(true);
        slotSelectionItems = GetComponentsInChildren<SelectWeaponSlot>(true);
    }
}
