using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [SerializeField] SerializableDictionary<ItemSO, WeaponSO> weapons = new();
    [SerializeField] SerializableDictionary<ItemSO, ArmorSO> armors = new();
    [SerializeField] SerializableDictionary<ItemSO, AccessorySO> accessories = new();
    [SerializeField] ItemSO item;

    private void Awake()
    {
        instance = this;
    }

    public object GetItem(ItemSO item)
    {
        switch (item.ItemType)
        {
            case Enums.ITEM_TYPE.WEAPON:
                return weapons.GetValue(item);
            case Enums.ITEM_TYPE.ARMOR:
                return armors.GetValue(item);
            case Enums.ITEM_TYPE.ACCESSORY:
                return accessories.GetValue(item);
            default:
                return null;
        }
    }
}