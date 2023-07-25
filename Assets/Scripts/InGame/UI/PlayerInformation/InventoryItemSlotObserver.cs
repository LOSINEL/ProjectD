using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class InventoryItemSlotObserver : MonoBehaviour, IPointerDownHandler, IInventoryObserver
{
    private Image _itemImage;
    private IInventorySubject _inventorySubject;

    [SerializeField]
    private InventoryItemSlotDragHandler _itemSlotDragHandler;

    void Start()
    {
        _itemImage = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
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

    public void Initialize(IInventorySubject subject)
    {
        _inventorySubject = subject;
        _inventorySubject.AddObserver(this);
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
