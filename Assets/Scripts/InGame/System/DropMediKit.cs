using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMediKit : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.instance.MediKit.FillMediKit();
    }
}