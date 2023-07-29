using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IInteractable
{
    [SerializeField] ItemSO item;

    public void SetItem(ItemSO itemData)
    {
        item = itemData;
    }

    public void Interact()
    {
        // Inventory.instance.AcquireItem(item);
    }
}