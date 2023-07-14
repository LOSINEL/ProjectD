using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventoryUIController : MonoBehaviour
{
    private void Start()
    {
        InventoryItemSlot[] itemSlots = GetComponentsInChildren<InventoryItemSlot>();

        Debug.Assert(InventoryManager.instance != null, "InventoryManager�� �Ҵ���� �ʾҽ��ϴ�.");
        foreach(InventoryItemSlot itemSlot in itemSlots)
        {
            itemSlot.Initialize(InventoryManager.instance);
        }
    }
}
