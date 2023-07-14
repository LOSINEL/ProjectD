using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class InventoryItemSlot :
    MonoBehaviour,
    IInventoryObserver,
    IPointerDownHandler
{
    private Image _itemImage;
    private IInventorySubject _inventorySubject;
    [SerializeField]
    private InventoryItemSlotDragHandler _itemSlotDragHandler;
    private Action _endDragCallback;

    void Start()
    {
        _itemImage = GetComponent<Image>();
    }

    public void Initialize(IInventorySubject inventorySubject)
    {
        Debug.Assert(inventorySubject != null, "InventorySubject가 null입니다.");

        _inventorySubject = inventorySubject;
        _inventorySubject.AddObserver(this);
    }

    public void UpdateObserver()
    {
        ItemSO item = _inventorySubject.GetItem(this);
        _itemImage.sprite = item.ItemSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_itemSlotDragHandler.IsDraggable)
        {
            _itemSlotDragHandler.StartDrag(
                this,
                _inventorySubject.GetItem(this));
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _itemSlotDragHandler.gameObject && IsItemSlotEmpty())
        {
            if (Input.GetMouseButtonUp(0))
            {
                _inventorySubject.SwapItem(
                    _itemSlotDragHandler.DragCallerObserver,
                    this);
            }
        }
    }

    private bool IsItemSlotEmpty()
    {
        return _inventorySubject.IsItemSlotEmpty(this);
    }
}
