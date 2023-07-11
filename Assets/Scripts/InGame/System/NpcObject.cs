using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcObject : MonoBehaviour, IInteractable
{
    [SerializeField] NpcSO npc;
    [SerializeField] Enums.UI_TYPE uiType;
    [SerializeField] bool interactable;

    public NpcSO Npc { get { return npc; } }

    public void Interact()
    {
        if (interactable)
        {
            // uiManager.instance.OpenWindow(uiType);
        }
    }
}