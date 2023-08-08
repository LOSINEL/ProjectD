using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class EquipmentItemSlot : IEquipmentSlot
{
    private Enums.ITEM_TYPE _equipmentType;
    private EquipmentSO _equipment;

    public EquipmentItemSlot(Enums.ITEM_TYPE equipmentType)
    {
        _equipmentType = equipmentType;
    }

    public Enums.ITEM_TYPE GetEquipmentType()
    {
        return _equipmentType;
    }

    public ItemSO GetItem()
    {
        return _equipment;
    }

    public void SetItem(ItemSO item)
    {
        _equipment = (EquipmentSO)item;
    }

    public bool IsEmpty()
    {
        return _equipment == null;
    }
}
