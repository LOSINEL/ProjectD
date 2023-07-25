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

    [SerializeField]
    private ItemSO _testItem;

    [SerializeField]
    private List<ItemSO> _inventory;
    private List<IItemSlot> _inventorySlotList;
    private List<IInventoryObserver> _inventoryObserverList;
    private Dictionary<Enums.ITEM_TYPE, EquipmentSO> _equipments;
    private List<IEquipmentSlot> _equipmentSlotList;
    private List<IEquipmentObserver> _equipmentObserverList;

    // �̷��� �ٲٱ�
    private List<(ItemSO, IInventoryObserver, IItemSlot)> _itemList;
    private List<(EquipmentSO, IEquipmentObserver, IItemSlot)> _equipmentList;

    private void Awake()
    {
        _instance = this;
        Initialize();
    }

    void Update()
    {
        // TODO
        // This anti pattern should be deleted.
        Notify();
    }

    private void Initialize()
    {
        _inventory = new();
        _equipments = new();
        _inventoryObserverList = new();
        _equipmentObserverList = new();
        _inventorySlotList = new();
        _equipmentSlotList = new();
    }

    /********** Implements of IInventorySubject **********/

    public void AddObserver(IInventoryObserver observer)
    {
        if (_inventoryObserverList.Contains(observer))
            return;

        _inventoryObserverList.Add(observer);
        _inventory.Add(null);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        int index = _inventoryObserverList.IndexOf(observer);
        if (index == -1)
            return;

        _inventoryObserverList.RemoveAt(index);
        _inventory.RemoveAt(index);
    }

    public void Notify()
    {
        foreach (IInventoryObserver observer in _inventoryObserverList)
        {
            observer.UpdateObserver();
        }
        foreach (IEquipmentObserver observer in _equipmentObserverList)
        {
            observer.UpdateObserver();
        }
    }

    public ItemSO GetState(IInventoryObserver observer)
    {
        int index = _inventoryObserverList.IndexOf(observer);

        if (index == -1)
            return null;
        return _inventory[index];
    }

    /********** Implements of IEquipmentSubject **********/

    public void AddObserver(IEquipmentObserver observer)
    {
        if (_equipmentObserverList.Contains(observer))
            return;

        _equipmentObserverList.Add(observer);
        _equipments.Add(observer.GetEquipmentType(), null);
    }

    public void RemoveObserver(IEquipmentObserver observer)
    {
        int index = _equipmentObserverList.IndexOf(observer);
        if (index == -1)
            return;

        _equipmentObserverList.RemoveAt(index);
        _equipments.Remove(observer.GetEquipmentType());
    }

    public EquipmentSO GetState(IEquipmentObserver observer)
    {
        int index = _equipmentObserverList.IndexOf(observer);

        if (index == -1)
            return null;
        return _equipments[observer.GetEquipmentType()];
    }

    /********** Implements of InventoryManager **********/

    public void AddItemSlot(IItemSlot itemSlot)
    {
        _inventorySlotList.Add(itemSlot);
    }

    public void RemoveItemSlot(IItemSlot itemSlot)
    {
        int index = _inventorySlotList.IndexOf(itemSlot);
        if (index == -1)
            return;

        _inventorySlotList.RemoveAt(index);
        _inventory.RemoveAt(index);
    }

    public void AddEquipmentSlot(IEquipmentSlot equipmentSlot)
    {
        if (_equipmentSlotList.Contains(equipmentSlot))
            return;

        _equipmentSlotList.Add(equipmentSlot);
    }

    public void RemoveEquipmentSlot(IEquipmentSlot equipmentSlot)
    {
        int index = _equipmentSlotList.IndexOf(equipmentSlot);
        if (index == -1)
            return;

        _equipmentSlotList.RemoveAt(index);
    }

    public void AddItem(ItemSO item)
    {
        int index = FindEmptySlotIndex();
        if (index == -1)
            return; // inventory is full.

        _inventory[index] = item;

        Notify();
    }

    private int FindEmptySlotIndex()
    {
        int index;
        for (index = 0; index < _inventorySlotList.Count; index++)
        {
            if (_inventorySlotList[index].IsEmpty())
            {
                return index;
            }
        }
        return -1;
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

    public void SetItemToSlot(ItemSO item, IItemSlot itemSlot)
    {
        int index = _inventorySlotList.IndexOf(itemSlot);
        if (index == -1)
            return;

        _inventory[index] = item;
    }

    public void SetEquipmentToSlot(EquipmentSO equipment, IEquipmentSlot equipmentSlot)
    {
        if (!_equipmentSlotList.Contains(equipmentSlot))
            return;

        _equipments[equipmentSlot.GetEquipmentType()] = equipment;
    }

    public bool IsInventoryFull()
    {
        foreach (IItemSlot itemSlot in _inventorySlotList)
        {
            if (itemSlot.IsEmpty())
            {
                return false;
            }
        }
        return true;
    }
}
