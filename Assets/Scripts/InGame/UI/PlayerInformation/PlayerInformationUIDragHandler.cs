using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInformationUIDragHandler
    : MonoBehaviour,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler
{
    private Vector2 distance;
    private bool IsDraggable = false;

    [SerializeField]
    private GameObject _playerInformationUITopBar;

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDraggable = eventData.hovered.Contains(_playerInformationUITopBar);

        if (IsDraggable)
        {
            distance = new(
                eventData.position.x - transform.position.x,
                eventData.position.y - transform.position.y
            );
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsDraggable)
        {
            transform.position = eventData.position - distance;
        }
    }

    public void OnEndDrag(PointerEventData eventData) { }
}
