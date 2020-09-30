using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour, ICancelHandler
{
    public ScoreInfo playerScoreInfo;
    public GameObject weaponsView;
    public RectTransform weaponsViewToInsertItems;
    public ScrollRect scrollRect;
    public GameObject slotSelectionView;
    public Button closeButton;
    public WeaponShopItem weaponShopItemPrefab;
    public SelectWeaponSlot selectWeaponSlotPrefab;
    public GameObject train;
    public WeaponInfo[] weaponInfoToBeSold;
    public UnityEvent onEnabled;
    public UnityEvent onDisabled;

    private WeaponShopItem[] shopItems;
    private SelectWeaponSlot[] slotSelectionItems;
    private WeaponInfo weaponBeingPurchased;
    private float scrollHeight;

    void Awake()
    {
        if (train == null)
        {
            train = GameObject.FindGameObjectWithTag("Train");
        }

        var weaponSlots = train.GetComponentsInChildren<WeaponSlot>(false);
        slotSelectionItems = Array.ConvertAll(weaponSlots, slot => {
            var newSelectionItem = Instantiate(selectWeaponSlotPrefab, slotSelectionView.transform);
            var rectTransform = newSelectionItem.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = slot.transform.position * rectTransform.rect.size;
            newSelectionItem.weaponShop = this;
            newSelectionItem.weaponSlot = slot;
            return newSelectionItem;
        });

        shopItems = Array.ConvertAll(weaponInfoToBeSold, weaponInfo => {
            var newShopItem = Instantiate(weaponShopItemPrefab, weaponsViewToInsertItems);
            newShopItem.weaponShop = this;
            newShopItem.SetWeaponInfo(weaponInfo);
            return newShopItem;
        });
    }

    public void ItemSelected(WeaponShopItem shopItem)
    {
        var itemRectTransform = shopItem.GetComponent<RectTransform>();
        var viewportHeight = scrollRect.viewport.rect.height;
        var contentHeight = weaponsViewToInsertItems.rect.height;
        var centerY = Mathf.Abs(itemRectTransform.anchoredPosition.y);

        float verticalNormalizedPosition;
        if (centerY < viewportHeight * 0.51f)
        {
            verticalNormalizedPosition = 1f;
        }
        else if (centerY > contentHeight - itemRectTransform.rect.height)
        {
            verticalNormalizedPosition = 0f;
        }
        else
        {
            verticalNormalizedPosition = 1f - (centerY / contentHeight);
        }

        scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
    }

    public void PurchaseWeaponItem(WeaponInfo weaponInfo)
    {
        Debug.Assert(playerScoreInfo.CanBuyWeapon(weaponInfo));
        weaponBeingPurchased = weaponInfo;
        ShowSelectSlot();
    }

    public void FinishPurchaseWeapon(WeaponSlot weaponSlot)
    {
        Debug.Assert(playerScoreInfo.CanBuyWeapon(weaponBeingPurchased));
        playerScoreInfo.Decrement(weaponBeingPurchased.scoreWorth);
        weaponSlot.SetWeapon(weaponBeingPurchased);
        weaponBeingPurchased = null;
        ShowSelectWeapon();
    }

    void ShowSelectWeapon()
    {
        weaponsView.SetActive(true);
        slotSelectionView.SetActive(false);
        Button interactableButton = null;
        foreach (var shopItem in shopItems)
        {
            if (shopItem.button.interactable)
            {
                ItemSelected(shopItem);
                interactableButton = shopItem.button;
                break;
            }
        }
        interactableButton = interactableButton ?? closeButton;
        interactableButton.Select();
    }

    void ShowSelectSlot()
    {
        weaponsView.SetActive(false);
        slotSelectionView.SetActive(true);
        slotSelectionItems[0].GetComponent<Button>().Select();
    }

    public void OnCancel(BaseEventData data)
    {
        CancelCurrentAction();
    }

    public void CancelCurrentAction()
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
}
