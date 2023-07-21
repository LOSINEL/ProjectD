using UnityEngine;
using UnityEngine.EventSystems;

public class ShopUIDragHandler : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler
{
    private Vector2 distance;
    private bool IsDraggable = false;
    [SerializeField]
    private GameObject _shopPopupTopBar;

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDraggable = eventData.hovered.Contains(_shopPopupTopBar);

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
}
