using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Assets.Scripts.InGame.System;

public class InventoryItemSlot : IItemSlot
{
    private ItemSO _item;

    public ItemSO GetItem()
    {
        return _item;
    }

    public void SetItem(ItemSO item)
    {
        _item = item;
    }

    public bool IsEmpty()
    {
        return _item == null;
    }
}
