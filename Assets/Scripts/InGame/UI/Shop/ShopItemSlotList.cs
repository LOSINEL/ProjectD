using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlotList : MonoBehaviour
{
    [SerializeField]
    private List<ShopItemSlot> _itemSlotList;

    public void Awake()
    {
        FindAllItemSlot();
    }

    private void FindAllItemSlot()
    {
        _itemSlotList = new();
        ShopItemSlot[] slots = GetComponentsInChildren<ShopItemSlot>();
        foreach(ShopItemSlot slot in slots)
        {
            _itemSlotList.Add(slot);
        }
    }

    public void ShowItemList(List<EquipmentSO> itemList)
    {
        for (int i = 0; i < _itemSlotList.Count; i++)
        {
            _itemSlotList[i].SetSlotImage(itemList[i]);
        }
    }
}
