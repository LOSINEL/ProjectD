using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class InventoryItemSlot :
    MonoBehaviour,
    IPointerDownHandler,
    IInventoryObserver,
    IItemSlot
{
    [SerializeField]
    private Sprite _slotImage;
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
        if (_itemSlotDragHandler.IsDraggable && !IsEmpty())
        {
            _itemSlotDragHandler.StartDrag(this);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _itemSlotDragHandler.gameObject)
        {
            if (Input.GetMouseButtonUp(0))
            {
                InventoryManager.instance.SwapItem(
                   _itemSlotDragHandler.DragTargetItemSlot,
                   this);
            }
        }
    }

    public void Initialize(IInventorySubject subject)
    {
        _inventorySubject = subject;
        _inventorySubject.AddObserver(this);

        InventoryManager.instance.AddItemSlot(this);
    }

    public void UpdateObserver()
    {
        ItemSO item = _inventorySubject.GetState(this);

        _itemImage.sprite = (item == null) ? _slotImage : item.ItemSprite;
    }

    public ItemSO GetItem()
    {
        return _inventorySubject.GetState(this);
    }

    public void SetItem(ItemSO item)
    {
        InventoryManager.instance.SetItemToSlot(item, this);
    }

    public bool IsEmpty()
    {
        return GetItem() == null;
    }
}
