using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;
using Assets.Scripts.InGame.UI.ContextMenu;

public class InventoryItemSlotObserver : MonoBehaviour, IPointerDownHandler, IInventoryObserver
{
    private Image _itemImage;
    private IInventorySubject _inventorySubject;

    [SerializeField]
    private InventoryItemSlotDragHandler _itemSlotDragHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InGameContextMenuController.Instance.OpenContextMenu(
                new EquipCompositeContextMenu(_inventorySubject.GetState(this)));
            return;
        }

        IItemSlot itemSlot = _inventorySubject.GetState(this);

        if (itemSlot.IsEmpty() || _itemSlotDragHandler.IsDraggable == false)
            return;

        _itemSlotDragHandler.StartDrag(itemSlot);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _itemSlotDragHandler.gameObject)
        {
            if (Input.GetMouseButtonUp(0))
            {
                InventoryManager.Instance.SwapItem(
                    _itemSlotDragHandler.DragTargetItemSlot,
                    _inventorySubject.GetState(this)
                );
            }
        }
    }

    // To update observer, it is inevitable getting 
    //  image component in Initialize(), not in Start().
    public void Initialize(IInventorySubject subject)
    {
        _itemImage = GetComponent<Image>();

        _inventorySubject = subject;
        _inventorySubject.AddObserver(this);

        UpdateObserver();
    }

    public void UpdateObserver()
    {
        IItemSlot itemSlot = _inventorySubject.GetState(this);

        if (itemSlot.IsEmpty())
        {
            _itemImage.enabled = false;
        }
        else
        {
            _itemImage.sprite = itemSlot.GetItem().ItemSprite;
            _itemImage.enabled = true;
        }
    }
}
