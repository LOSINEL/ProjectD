using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts.InGame.System;

public class InventoryItemSlotDragHandler : MonoBehaviour
{
    [SerializeField]
    private bool _isDragging = false;
    [SerializeField]
    private Image _itemImage;
    [SerializeField]
    private Collider2D _collider2d;
    private IInventoryObserver _dragCallerObserver;

    public IInventoryObserver DragCallerObserver
    {
        get
        {
            return _dragCallerObserver;
        }
    }

    public bool IsDraggable { get { return _isDragging == false; } }

    private void Start()
    {
        _itemImage = GetComponent<Image>();
        _collider2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                MoveToMousePointer();
            }
            else
            {
                EndDrag();
            }
        }
    }

    private void MoveToMousePointer()
    {
        transform.position = Input.mousePosition;
    }

    public void StartDrag(IInventoryObserver dragCallerObserver, ItemSO item)
    {
        _dragCallerObserver = dragCallerObserver;
        _itemImage.sprite = item.ItemSprite;

        _itemImage.enabled = true;
        _collider2d.enabled = true;
        _isDragging = true;
    }

    public void EndDrag()
    {
        _itemImage.enabled = false;
        _collider2d.enabled = false;
        _isDragging = false;
    }
}
