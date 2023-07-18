using UnityEngine;

using Assets.Scripts.InGame.System;

public class PlayerInventoryUIController : MonoBehaviour
{
    private void Start()
    {
        IInventoryObserver[] _inventoryObservers = GetComponentsInChildren<IInventoryObserver>();

        foreach (IInventoryObserver _itemSlot in _inventoryObservers)
        {
            _itemSlot.Initialize(InventoryManager.instance);
        }
    }
}
