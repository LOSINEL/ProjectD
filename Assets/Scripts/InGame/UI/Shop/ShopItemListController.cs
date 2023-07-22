using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using ITEM_TYPE = Enums.ITEM_TYPE;
using ITEM_GRADE = Enums.ITEM_GRADE;

public class ShopItemListController : MonoBehaviour
{
    private Dictionary<ITEM_TYPE, Dictionary<ITEM_GRADE, List<EquipmentSO>>> _shopItemDatabase;
    private List<EquipmentSO> _shopItemList;
    private const string _weaponItemPath = "/Assets/Data/Item/Equipment/Weapon/";
    private const string _armorItemPath = "/Assets/Data/Item/Equipment/Armor/";
    private const string _accessoryItemPath = "/Assets/Data/Item/Equipment/Accessory/";

    [SerializeField]
    private ShopItemSlotList _normalItemSlotList;

    [SerializeField]
    private ShopItemSlotList _rareItemSlotList;

    [SerializeField]
    private ShopItemSlotList _epicItemSlotList;
    [SerializeField]
    private List<WeaponSO> _weaponList;
    [SerializeField]
    private List<ArmorSO> _armorList;
    [SerializeField]
    private List<AccessorySO> _accessoryList;

    void Start()
    {
        LoadShopItemList();
        ShowWeaponList();
    }

    private void LoadShopItemList()
    {
        Array itemTypeArray = ITEM_TYPE.GetValues(typeof(ITEM_TYPE));
        Array itemGradeArray = ITEM_GRADE.GetValues(typeof(ITEM_GRADE));

        // create database structure.
        _shopItemDatabase = new();
        foreach (ITEM_TYPE itemType in itemTypeArray)
        {
            _shopItemDatabase.Add(itemType, new Dictionary<ITEM_GRADE, List<EquipmentSO>>());
        }
        foreach (ITEM_TYPE itemType in itemTypeArray)
        {
            foreach (ITEM_GRADE itemGrade in itemGradeArray)
            {
                _shopItemDatabase[itemType].Add(itemGrade, new List<EquipmentSO>());
            }
        }

        // add items into database.
        foreach (EquipmentSO weapon in _weaponList)
        {
            if (weapon.Grade == ITEM_GRADE.LEGENDARY)
                break;

            _shopItemDatabase[ITEM_TYPE.WEAPON][weapon.Grade].Add(weapon);
        }
        foreach (EquipmentSO armor in _armorList)
        {
            if (armor.Grade == ITEM_GRADE.LEGENDARY)
                break;

            _shopItemDatabase[ITEM_TYPE.ARMOR][armor.Grade].Add(armor);
        }
        foreach (EquipmentSO accessory in _accessoryList)
        {
            if (accessory.Grade == ITEM_GRADE.LEGENDARY)
                break;

            _shopItemDatabase[ITEM_TYPE.ACCESSORY][accessory.Grade].Add(accessory);
        }
    }

    public void ShowWeaponList()
    {
        _normalItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.WEAPON][ITEM_GRADE.NORMAL]);
        _rareItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.WEAPON][ITEM_GRADE.RARE]);
        _epicItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.WEAPON][ITEM_GRADE.EPIC]);
    }

    public void ShowArmorList()
    {
        _normalItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.ARMOR][ITEM_GRADE.NORMAL]);
        _rareItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.ARMOR][ITEM_GRADE.RARE]);
        _epicItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.ARMOR][ITEM_GRADE.EPIC]);
    }

    public void ShowAccessoryList()
    {
        _normalItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.ACCESSORY][ITEM_GRADE.NORMAL]);
        _rareItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.ACCESSORY][ITEM_GRADE.RARE]);
        _epicItemSlotList.ShowItemList(_shopItemDatabase[ITEM_TYPE.ACCESSORY][ITEM_GRADE.EPIC]);
    }
}
