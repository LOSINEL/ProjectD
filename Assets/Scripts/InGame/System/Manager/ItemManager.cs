using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [SerializeField] SerializableDictionary<ItemSO, WeaponSO> weapons = new();
    [SerializeField] SerializableDictionary<ItemSO, ArmorSO> armors = new();
    [SerializeField] SerializableDictionary<ItemSO, AccessorySO> accessories = new();
    [SerializeField] GameObject dropItem;

    public GameObject DropItem { get { return dropItem; } }

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

    public EquipmentSO GetRandomItem(Enums.ITEM_GRADE itemGrade)
    {
        int itemType = Random.Range(0, (int)Enums.ITEM_TYPE.ENUM_SIZE);
        switch(itemType)
        {
            case 0:
                while (true)
                {
                    EquipmentSO tmp = weapons.GetValue(Random.Range(0, weapons.Count));
                    if (tmp.Grade == itemGrade)
                        return tmp;
                }
            case 1:
                while (true)
                {
                    EquipmentSO tmp = armors.GetValue(Random.Range(0, armors.Count));
                    if (tmp.Grade == itemGrade)
                        return tmp;
                }
            case 2:
                while (true)
                {
                    EquipmentSO tmp = accessories.GetValue(Random.Range(0, accessories.Count));
                    if (tmp.Grade == itemGrade)
                        return tmp;
                }
            default:break;
        }
        return null;
    }
}