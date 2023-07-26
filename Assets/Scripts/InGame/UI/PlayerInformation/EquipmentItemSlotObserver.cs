using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class EquipmentItemSlotObserver : MonoBehaviour, IPointerDownHandler, IEquipmentObserver
{
    private Image _itemImage;
    private IEquipmentSubject _equipmentSubject;

    [SerializeField]
    private InventoryItemSlotDragHandler _itemSlotDragHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        IEquipmentSlot equipmentSlot = _equipmentSubject.GetState(this);

        if (equipmentSlot.IsEmpty() || _itemSlotDragHandler.IsDraggable == false)
            return;

        _itemSlotDragHandler.StartDrag(equipmentSlot);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _itemSlotDragHandler.gameObject)
        {
            if (Input.GetMouseButtonUp(0))
            {
                InventoryManager.Instance.SwapItem(
                    _itemSlotDragHandler.DragTargetItemSlot,
                    _equipmentSubject.GetState(this)
                );
            }
        }
    }

    // To update observer, it is inevitable getting 
    //  image component in Initialize(), not in Start().
    public void Initialize(IEquipmentSubject subject)
    {
        _itemImage = GetComponent<Image>();

        _equipmentSubject = subject;
        _equipmentSubject.AddObserver(this);

        UpdateObserver();
    }

    public void UpdateObserver()
    {
        IEquipmentSlot itemSlot = _equipmentSubject.GetState(this);

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
