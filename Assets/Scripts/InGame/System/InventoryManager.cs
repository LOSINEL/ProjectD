using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.InGame.System;

struct ItemSlotObserverPair
{
    public IInventoryObserver observer;
    public IItemSlot itemSlot;

    public ItemSlotObserverPair(IInventoryObserver observer, IItemSlot itemSlot)
    {
        this.observer = observer;
        this.itemSlot = itemSlot;
    }
}

struct EquipmentSlotObserverPair
{
    public IEquipmentObserver observer;
    public IEquipmentSlot equipmentSlot;

    public EquipmentSlotObserverPair(IEquipmentObserver observer, IEquipmentSlot equipmentSlot)
    {
        this.observer = observer;
        this.equipmentSlot = equipmentSlot;
    }
}

class InventoryManager
    : SingletonMonoBehavior<InventoryManager>,
        IInventorySubject,
        IEquipmentSubject
{
    private List<ItemSlotObserverPair> _inventory;
    private List<EquipmentSlotObserverPair> _equipments;

    [SerializeField]
    private int _gold;
    public int Gold
    {
        get { return _gold; }
    }

#region Initialization
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _inventory = new();
        _equipments = new();
        AddItemSlot(Nums.maxInventoryItemSlotCount);
        AddEquipmentSlot(Enums.ITEM_TYPE.WEAPON);
        AddEquipmentSlot(Enums.ITEM_TYPE.ARMOR);
        AddEquipmentSlot(Enums.ITEM_TYPE.ACCESSORY);

        _gold = 9999;
    }

    public void AddItemSlot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _inventory.Add(new ItemSlotObserverPair(null, new InventoryItemSlot()));
        }
    }

    public void AddEquipmentSlot(Enums.ITEM_TYPE itemType)
    {
        _equipments.Add(new EquipmentSlotObserverPair(null, new EquipmentItemSlot(itemType)));
    }
#endregion Initialization
#region IInventorySubject
    public void AddObserver(IInventoryObserver observer)
    {
        // find pair what has null IInventoryObserver.
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].observer == null)
            {
                // Item in list cannot be changed.
                // so assign copy of original which is modified instead modify directly.
                ItemSlotObserverPair pair = _inventory[i];
                pair.observer = observer;
                _inventory[i] = pair;
                break;
            }
        }
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].observer == observer)
            {
                _inventory.RemoveAt(i);
                return;
            }
        }
    }

    public IItemSlot GetState(IInventoryObserver observer)
    {
        foreach (ItemSlotObserverPair pair in _inventory)
        {
            if (pair.observer == observer)
            {
                return pair.itemSlot;
            }
        }
        return null;
    }
#endregion IInventorySubject
#region IEquipmentSubject
    public void AddObserver(IEquipmentObserver observer)
    {
        // find pair what has null IEquipmentObserver.
        for (int i = 0; i < _equipments.Count; i++)
        {
            if (_equipments[i].observer == null)
            {
                // Item in list cannot be changed.
                // so assign copy of original which is modified instead modify directly.
                EquipmentSlotObserverPair pair = _equipments[i];
                pair.observer = observer;
                _equipments[i] = pair;
                break;
            }
        }
    }

    public void RemoveObserver(IEquipmentObserver observer)
    {
        for (int i = 0; i < _equipments.Count; i++)
        {
            if (_equipments[i].observer == observer)
            {
                _equipments.RemoveAt(i);
                return;
            }
        }
    }

    public IEquipmentSlot GetState(IEquipmentObserver observer)
    {
        foreach (EquipmentSlotObserverPair pair in _equipments)
        {
            if (pair.observer == observer)
            {
                return pair.equipmentSlot;
            }
        }
        return null;
    }
#endregion IEquipmentSubject
#region ISubject.Notify
    public void Notify()
    {
        foreach (ItemSlotObserverPair pair in _inventory)
        {
            if (pair.observer != null)
            {
                pair.observer.UpdateObserver();
            }
        }
        foreach (EquipmentSlotObserverPair pair in _equipments)
        {
            if (pair.observer != null)
            {
                pair.observer.UpdateObserver();
            }
        }
    }
#endregion ISubject
#region InventoryManager
    ///<summary>
    ///Equip an item in inventory to equipment.
    ///<param name="itemSlot">An one of item slot in inventory.</param>
    ///</summary>
    public void EquipItem(IItemSlot itemSlot)
    {
        ItemSO item = itemSlot.GetItem();
        if (item is not EquipmentSO)
            return;

        EquipmentSlotObserverPair pair = _equipments.Find(
            pair => pair.equipmentSlot.GetEquipmentType() == item.ItemType
        );
        SwapItem(itemSlot, pair.equipmentSlot);
    }

    public void UnequipItem(IItemSlot itemSlot)
    {
        ItemSO item = itemSlot.GetItem();
        itemSlot.SetItem(null);
        AddItem(item);
    }

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

    public void RefundItem(IItemSlot itemSlot)
    {
        ItemSO item = itemSlot.GetItem();

        // TODO
        // This is temporary value for test.
        // It should be fixed after create ItemPrice value in ItemSO.
        int price = 150;

        itemSlot.SetItem(null);
        InventoryManager.Instance.AddGold(price);
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
        foreach (ItemSlotObserverPair pair in _inventory)
        {
            if (pair.itemSlot.IsEmpty())
            {
                return pair.itemSlot;
            }
        }
        return null;
    }
#endregion InventoryManager
#region GoldSystem
    public bool IsInventoryFull()
    {
        foreach (ItemSlotObserverPair pair in _inventory)
        {
            if (pair.itemSlot.IsEmpty())
            {
                return false;
            }
        }
        return true;
    }

    public void AddGold(int goldAmount)
    {
        _gold += goldAmount;
    }

    public void MinusGold(int goldAmount)
    {
        if (_gold - goldAmount > 0)
        {
            _gold -= goldAmount;
        }
    }
#endregion GoldSystem
}
