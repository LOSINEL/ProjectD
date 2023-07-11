using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcObject : MonoBehaviour
{
    [SerializeField] NpcSO npc;

    public NpcSO Npc { get { return npc; } }
}