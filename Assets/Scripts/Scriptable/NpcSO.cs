using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NpcSO : ScriptableObject
{
    [SerializeField] string npcName;
    [SerializeField] string npcInfo;

    public string NpcName { get { return npcName; } }
    public string NpcInfo { get { return npcInfo; } }
}