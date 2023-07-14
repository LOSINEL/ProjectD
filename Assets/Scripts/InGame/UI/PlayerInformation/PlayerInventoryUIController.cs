using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventoryUIController : MonoBehaviour
{
    private void Start()
    {
        InventoryItemSlot[] itemSlots = GetComponentsInChildren<InventoryItemSlot>();

        Debug.Assert(InventoryManager.instance != null, "InventoryManager가 할당되지 않았습니다.");
        foreach(InventoryItemSlot itemSlot in itemSlots)
        {
            itemSlot.Initialize(InventoryManager.instance);
        }
    }
}
