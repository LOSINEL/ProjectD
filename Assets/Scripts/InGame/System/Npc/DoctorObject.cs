using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorObject : NpcObject,IInteractable
{
    public void Interact()
    {
        Debug.Log("heal window open");
    }
}