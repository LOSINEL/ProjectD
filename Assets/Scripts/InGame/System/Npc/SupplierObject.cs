using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplierObject : NpcObject, IInteractable
{
    public void Interact()
    {
        Debug.Log("shop window open");
        // 상점 윈도우 열기
    }
}