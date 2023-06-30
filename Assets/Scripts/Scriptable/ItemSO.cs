using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string itemInfo;
    [SerializeField] Enums.ITEM_TYPE itemType;

    public string ItemName { get { return itemName; } }
    public string ItemInfo { get { return itemInfo; } }
    public Enums.ITEM_TYPE ItemType { get { return itemType; } }
}