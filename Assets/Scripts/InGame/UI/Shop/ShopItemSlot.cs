using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Assets.Scripts.InGame.UI.Shop;

public class ShopItemSlot : MonoBehaviour, IPointerDownHandler
{
    private ItemSO _item;
    private Image _slotImage;

    [SerializeField]
    private ShopPurchaseConfirmPopupController _controller;

    private void Awake()
    {
        _slotImage = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            OpenPurchaseContextMenuIfSlotHasItem();
        }
    }

    public void OpenPurchaseContextMenuIfSlotHasItem()
    {
        if (SlotHasItem())
            return;

        _controller.OpenShopPurchaseConfirmPopupUI(_item);
    }

    private bool SlotHasItem()
    {
        return _item == null;
    }

    public void SetSlotImage(ItemSO item)
    {
        _item = item;

        if (_item.ItemSprite == null)
        {
            _slotImage.enabled = false;
        }
        else
        {
            _slotImage.enabled = true;
            _slotImage.sprite = _item.ItemSprite;
        }
    }
}
