using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.InGame.System;

class InventoryManager : MonoBehaviour, IInventorySubject
{
    public static InventoryManager instance;

    [SerializeField]
    private List<ItemSO> _itemList;
    [SerializeField]
    private List<IInventoryObserver> _inventoryObserverList;
    [SerializeField]
    private ItemSO _emptyItemSO;

    private void Awake()
    {
        instance = this;
        Initialize();
    }

    private void Initialize()
    {
        _inventoryObserverList = new();
        _itemList = new();
    }

    public void AddObserver(IInventoryObserver inventoryObserver)
    {
        if (_inventoryObserverList.Contains(inventoryObserver)) return;

        _inventoryObserverList.Add(inventoryObserver);
        _itemList.Add(_emptyItemSO);
    }

    public void RemoveObserver(IInventoryObserver inventoryObserver)
    {
        int index = _inventoryObserverList.IndexOf(inventoryObserver);
        if (index == -1) return;
        
        _inventoryObserverList.Remove(inventoryObserver);
        _itemList.RemoveAt(index);
    }

    public void AddItem(ItemSO item)
    {
        if (IsInventoryFull()) return;

        int index;
        for(index = 0; index < _itemList.Count; index++)
        {
            if(_itemList[index] == _emptyItemSO)
            {
                break;
            }
        }
        _itemList[index] = item;

        Notify();
    }

    public void RemoveItem(ItemSO item)
    {
        int index = _itemList.IndexOf(item);
        if (index == -1) return;

        _itemList[index] = _emptyItemSO;
        Notify();
    }

    public void SwapItem(IInventoryObserver inventoryObserverA, IInventoryObserver inventoryObserverB)
    {
        int indexA = _inventoryObserverList.IndexOf(inventoryObserverA);
        int indexB = _inventoryObserverList.IndexOf(inventoryObserverB);
        (_itemList[indexA], _itemList[indexB]) = (_itemList[indexB], _itemList[indexA]);

        Notify();
    }

    /// <summary>
    /// _itemList에 어떤 내용이 수정되었다면 무조건 이 함수가 호출되어
    /// 모든 아이템 슬롯칸이 변경을 인지하도록 해야합니다.
    /// </summary>
    public void Notify()
    {
        for (int i = 0; i < _inventoryObserverList.Count; i++)
        {
            _inventoryObserverList[i].UpdateObserver();
        }
    }

    public ItemSO GetItem(IInventoryObserver inventoryObserver)
    {
        int index = _inventoryObserverList.IndexOf(inventoryObserver);
        if (index >= _itemList.Count) return null;

        return _itemList[index];
    }

    public bool IsInventoryFull()
    {
        foreach(ItemSO item in _itemList)
        {
            if(item == _emptyItemSO)
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        Notify();
    }
}
