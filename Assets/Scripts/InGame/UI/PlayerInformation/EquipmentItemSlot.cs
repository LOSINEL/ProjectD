using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class EquipmentItemSlot :
    MonoBehaviour,
    IPointerDownHandler,
    IEquipmentObserver,
    IEquipmentSlot
{
    [SerializeField]
    private Sprite _slotImage;
    private Image _itemImage;
    private IEquipmentSubject _equipmentSubject;
    [SerializeField]
    private Enums.ITEM_TYPE _equipmentType;
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
                InventoryManager.Instance.SwapItem(
                   _itemSlotDragHandler.DragTargetItemSlot,
                   this);
            }
        }
    }

    public void Initialize(IEquipmentSubject subject)
    {
        _equipmentSubject = subject;
        _equipmentSubject.AddObserver(this);

        InventoryManager.Instance.AddEquipmentSlot(this);
    }

    public void UpdateObserver()
    {
        ItemSO item = _equipmentSubject.GetState(this);

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

    public Enums.ITEM_TYPE GetEquipmentType()
    {
        return _equipmentType;
    }

    public ItemSO GetItem()
    {
        return _equipmentSubject.GetState(this);
    }

    public void SetItem(ItemSO item)
    {
        InventoryManager.Instance.SetEquipmentToSlot((EquipmentSO)item, this);
    }

    public bool IsEmpty()
    {
        return GetItem() == null;
    }
}

