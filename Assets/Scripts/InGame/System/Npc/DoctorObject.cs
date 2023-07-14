using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorObject : NpcObject,IInteractable
{
    public void Interact()
    {
        Debug.Log("heal window open");
        // 무료 힐, 돈 내고 메디키트 구매
    }
}