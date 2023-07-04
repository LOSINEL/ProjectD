using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentUIController : MonoBehaviour
{
    [SerializeField]
    private Dictionary<Enums.ITEM_TYPE, Image> _equipmentSlots;
    [SerializeField]
    private Sprite _mockItemSprite;

    private readonly Enums.ITEM_TYPE[] _equipmentSlotsOrder = {
        Enums.ITEM_TYPE.WEAPON,
        Enums.ITEM_TYPE.ARMOR,
        Enums.ITEM_TYPE.ACCESSORY,
        Enums.ITEM_TYPE.CONSUMABLE
    };

    void Start()
    {
        _equipmentSlots = new Dictionary<Enums.ITEM_TYPE, Image>();

        Image[] slots = GetComponentsInChildren<Image>();

        /// TODO
        /// 그리드 레이아웃 내에 생성되어있는 이미지의 개수와
        /// _equipmentSlotsOrder의 길이가 동일하지 않으면 에러를 일으킨다.
        /// 하지만 이미지의 개수를 변경시켰을 때 동적으로 _equipmentSlotsOrder에
        /// 항목을 추가되지 않는다. 동적으로 추가하도록 변경해야하는지 고민할 것.
        Debug.Assert(slots.Length == _equipmentSlotsOrder.Length, 
            $"Slot length = {slots.Length}\n equipmentSlotsOrder length = ${_equipmentSlotsOrder.Length}");

        for(int i = 0; i < slots.Length; i++)
        {
            _equipmentSlots.Add(_equipmentSlotsOrder[i], slots[i]);
        }
    }

    public void UpdateEquipmentSlot(ItemSO item)
    {
        Sprite sprite = GetItemSprite(item);
        _equipmentSlots[item.ItemType].sprite = sprite;
    }

    /// <summary>
    /// TODO
    /// 테스트를 위해 디폴트 이미지를 반환하게 만들었는데,
    /// 아이템의 이름에 따라 직접 sprite객체를 반환하도록 구현해야한다.
    /// </summary>
    /// <param name="item">아이템 객체</param>
    /// <returns></returns>
    private Sprite GetItemSprite(ItemSO item)
    {
        return _mockItemSprite;
    }
}
