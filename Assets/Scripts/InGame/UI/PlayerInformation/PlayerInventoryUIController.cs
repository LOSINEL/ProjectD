using UnityEngine;

using Assets.Scripts.InGame.System;

public class PlayerInventoryUIController : MonoBehaviour
{
    private void Start()
    {
        IInventoryObserver[] inventoryObservers = GetComponentsInChildren<IInventoryObserver>();

        foreach (IInventoryObserver observer in inventoryObservers)
        {
            observer.Initialize(InventoryManager.Instance);
        }
    }
}
