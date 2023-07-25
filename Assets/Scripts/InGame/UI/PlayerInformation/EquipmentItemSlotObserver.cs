using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class EquipmentItemSlotObserver : 
    MonoBehaviour,
    IPointerDownHandler,
    IEquipmentObserver
{
    private Image _itemImage;
    private IEquipmentSubject _equipmentSubject;
    [SerializeField]
    private InventoryItemSlotDragHandler _itemSlotDragHandler;

    void Start()
    {
        _itemImage = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EquipmentSO equipment = _equipmentSubject.GetState(this);
        if (_itemSlotDragHandler.IsDraggable && equipment != null)
        {
            // _itemSlotDragHandler.StartDrag(this);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _itemSlotDragHandler.gameObject)
        {
            if (Input.GetMouseButtonUp(0))
            {
                // InventoryManager.Instance.SwapItem(
                //    _itemSlotDragHandler.DragTargetItemSlot,
                //    this);
            }
        }
    }

    public void Initialize(IEquipmentSubject subject)
    {
        _equipmentSubject = subject;
        _equipmentSubject.AddObserver(this);
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
}
