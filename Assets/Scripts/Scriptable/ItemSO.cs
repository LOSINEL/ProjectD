using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string itemInfo;
    [SerializeField] Enums.ITEM_TYPE itemType;
    [SerializeField] Material material;
    [SerializeField] Sprite itemSprite;

    public string ItemName { get { return itemName; } }
    public string ItemInfo { get { return itemInfo; } }
    public Enums.ITEM_TYPE ItemType { get { return itemType; } }
    public Material Material { get { return material; } }
    public Sprite ItemSprite { get { return itemSprite; } }
}