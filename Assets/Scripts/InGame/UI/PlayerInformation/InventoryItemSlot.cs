using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

using Assets.Scripts.InGame.System;

public class InventoryItemSlot :
    MonoBehaviour,
    IInventoryObserver,
    IPointerDownHandler,
    IPointerUpHandler
{
    private Image _itemImage;
    private IInventorySubject _inventorySubject;

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
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // if player do dragging slot, stop dragging.
        // if slot collide with other slot, swap item.
    }
}
