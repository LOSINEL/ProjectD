using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.InGame.System;

class InventoryManager : MonoBehaviour, IInventorySubject, IEquipmentSubject
{

    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get { return _instance; }
    }

    private List<(IInventoryObserver, IItemSlot)> _itemList;
    private List<(IEquipmentObserver, IEquipmentSlot)> _equipmentList;

    private void Awake()
    {
        _instance = this;
        Initialize();
    }

    private void Initialize()
    {
        
        _itemList = new();
        _equipmentList = new();
        AddItemSlot(Nums.maxInventoryItemSlotCount);
        AddEquipmentSlot(Enums.ITEM_TYPE.WEAPON);
        AddEquipmentSlot(Enums.ITEM_TYPE.ARMOR);
        AddEquipmentSlot(Enums.ITEM_TYPE.ACCESSORY);
    }

    public void AddItemSlot(int count)
    {
        for(int i = 0; i < count; i++)
        {
            _itemList.Add((null, new InventoryItemSlot()));
        }
    }

    public void AddEquipmentSlot(Enums.ITEM_TYPE itemType)
    {
        _equipmentList.Add((null, new EquipmentItemSlot(itemType)));
    }

    /********** Implements of IInventorySubject **********/

    public void AddObserver(IInventoryObserver observer)
    {
        // find tuple what has null IInventoryObserver.
        for(int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].Item1 == null)
            {
                // Item in tuple cannot be changed.
                // so assign new tuple with current one.
                _itemList[i] = (observer, _itemList[i].Item2);
                _itemList[i].Item1.UpdateObserver();
                break;
            }
        }
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        for(int i = 0; i < _itemList.Count; i++)
        {
            if(_itemList[i].Item1 == observer)
            {
                _itemList.RemoveAt(i);
                return;
            }
        }
    }

    public ItemSO GetState(IInventoryObserver observer)
    {
        foreach((IInventoryObserver, IItemSlot) tuple in _itemList)
        {
            if(tuple.Item1 == observer)
            {
                return tuple.Item2.GetItem();
            }
        }
        return null;
    }

    /********** Implements of IEquipmentSubject **********/

    public void AddObserver(IEquipmentObserver observer)
    {
        // find tuple what has null IEquipmentObserver.
        for(int i = 0; i < _equipmentList.Count; i++)
        {
            if (_equipmentList[i].Item1 == null)
            {
                // Item in tuple cannot be changed.
                // so assign new tuple with current one.
                _equipmentList[i] = (observer, _equipmentList[i].Item2);
                _equipmentList[i].Item1.UpdateObserver();
                break;
            }
        }
    }

    public void RemoveObserver(IEquipmentObserver observer)
    {
        for(int i = 0; i < _equipmentList.Count; i++)
        {
            if(_equipmentList[i].Item1 == observer)
            {
                _equipmentList.RemoveAt(i);
                return;
            }
        }
    }

    public EquipmentSO GetState(IEquipmentObserver observer)
    {
        foreach((IEquipmentObserver, IItemSlot) tuple in _equipmentList)
        {
            if(tuple.Item1 == observer)
            {
                return (EquipmentSO)tuple.Item2.GetItem();
            }
        }
        return null;
    }

    public void Notify()
    {
        foreach((IInventoryObserver, IItemSlot) tuple in _itemList)
        {
            if(tuple.Item1 != null)
            {
                tuple.Item1.UpdateObserver();
            }
        }
        foreach((IEquipmentObserver, IItemSlot) tuple in _equipmentList)
        {
            if(tuple.Item1 != null)
            {
                tuple.Item1.UpdateObserver();
            }
        }
    }

    /********** Implements of InventoryManager **********/

    public void SwapItem(IItemSlot itemSlotA, IItemSlot itemSlotB)
    {
        /*
         * inventory to equipment (need to check type)
         * equipment to equipment (need to check type)
         * equipment to inventory (if inventory item is not null,
         *                         need to check type)
         * inventory to inventory (no need to check type)
         */
        ItemSO itemA = itemSlotA.GetItem();
        ItemSO itemB = itemSlotB.GetItem();
        if (itemSlotB is IEquipmentSlot)
        {
            // inventory to equipment
            // equipment to inventory
            // need to check type
            if (itemB != null)
            {
                if (itemA.ItemType != itemB.ItemType)
                    return;
            }
            else
            {
                if (itemA.ItemType != ((IEquipmentSlot)itemSlotB).GetEquipmentType())
                    return;
            }
        }
        else if (itemSlotA is IEquipmentSlot)
        {
            // equipment to inventory
            // need to check type if inventory item is not null.
            if (itemB != null)
            {
                if (itemA.ItemType != itemB.ItemType)
                    return;
            }
        }
        else { }
        ItemSO item = itemSlotA.GetItem();
        itemSlotA.SetItem(itemSlotB.GetItem());
        itemSlotB.SetItem(item);

        Notify();
    }

    public void AddItem(ItemSO item)
    {
        IItemSlot itemSlot = GetEmptyInventorySlot();
        if (itemSlot == null)
            return;

        itemSlot.SetItem(item);

        Notify();
    }

    public IItemSlot GetEmptyInventorySlot()
    {
        foreach((IInventoryObserver, IItemSlot) tuple in _itemList)
        {
            if (tuple.Item2.IsEmpty()){
                return tuple.Item2;
            }
        }
        return null;
    }

    public bool IsInventoryFull()
    {
        foreach((IInventoryObserver, IItemSlot) tuple in _itemList)
        {
            if(tuple.Item2.IsEmpty())
            {
                return false;
            }
        }
        return true;
    }
}
