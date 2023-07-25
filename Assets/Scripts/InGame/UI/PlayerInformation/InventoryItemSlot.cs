using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class InventoryItemSlot : MonoBehaviour, IPointerDownHandler, IInventoryObserver, IItemSlot
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
                InventoryManager.Instance.SwapItem(_itemSlotDragHandler.DragTargetItemSlot, this);
            }
        }
    }

    public void Initialize(IInventorySubject subject)
    {
        _inventorySubject = subject;
        _inventorySubject.AddObserver(this);

        InventoryManager.Instance.AddItemSlot(this);
    }

    public void UpdateObserver()
    {
        ItemSO item = _inventorySubject.GetState(this);

        if (item == null)
        {
            _itemImage.enabled = false;
        }
        else
        {
            _itemImage.sprite = item.ItemSprite;
            _itemImage.enabled = true;
        }
    }

    public ItemSO GetItem()
    {
        return _inventorySubject.GetState(this);
    }

    public void SetItem(ItemSO item)
    {
        InventoryManager.Instance.SetItemToSlot(item, this);
    }

    public bool IsEmpty()
    {
        return GetItem() == null;
    }
}
