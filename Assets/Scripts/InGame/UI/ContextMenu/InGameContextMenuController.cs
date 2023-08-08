using UnityEngine;

using Assets.Scripts.InGame.UI.ContextMenu;


public class InGameContextMenuController : SingletonMonoBehavior<InGameContextMenuController>
{
    [SerializeField]
    private GameObject _contextMenuPrefab;
    private enum State
    {
        Awaked, // prevent to close re-opened context menu.
        Opened,
        Closed,
    };
    private State _state;


    private void Start()
    {
        SetState(State.Closed);
    }

    private void Update()
    {
        // Listener will called after this function called.
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            if(!IsAwaked() && Input.GetMouseButtonUp(0))
            {
                CloseContextMenu();
            }
        }
        if (IsAwaked())
        {
            SetState(State.Opened);
        }
    }

    public void OpenContextMenu(IContextMenu contextMenu)
    {
        if (!IsClosed())
        {
            CloseContextMenu();
        }

        transform.position = Input.mousePosition;

        // create menu object list by structure.
        CreateContextMenuList(transform.position, contextMenu);

        SetState(State.Awaked);
    }

    public void CreateContextMenuList(Vector3 targetPosition, IContextMenu contextMenu)
    {
        foreach (IContextMenu child in contextMenu.GetChildList())
        {
            // create actual button object.
            GameObject prefab = Instantiate(
                _contextMenuPrefab,
                targetPosition,
                Quaternion.identity
            );
            // set prefab's parent to this.
            prefab.transform.SetParent(transform);

            ContextMenuButton contextMenuButton = prefab.GetComponent<ContextMenuButton>();
            contextMenuButton.Initialize(child);
        }
    }

    public void CloseContextMenu()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }

        SetState(State.Closed);
    }

    private void SetState(State state)
    {
        _state = state;
    }

    private bool IsClosed()
    {
        return _state == State.Closed;
    }

    private bool IsOpened()
    {
        return _state == State.Opened;
    }

    private bool IsAwaked()
    {
        return _state == State.Awaked;
    }
}
