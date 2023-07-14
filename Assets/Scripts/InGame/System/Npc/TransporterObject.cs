using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterObject : NpcObject, IInteractable
{
    public void Interact()
    {
        Debug.Log("map window open");
        // 맵 윈도우 열기
    }
}