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
        /// �׸��� ���̾ƿ� ���� �����Ǿ��ִ� �̹����� ������
        /// _equipmentSlotsOrder�� ���̰� �������� ������ ������ ����Ų��.
        /// ������ �̹����� ������ ��������� �� �������� _equipmentSlotsOrder��
        /// �׸��� �߰����� �ʴ´�. �������� �߰��ϵ��� �����ؾ��ϴ��� ����� ��.
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
    /// �׽�Ʈ�� ���� ����Ʈ �̹����� ��ȯ�ϰ� ������µ�,
    /// �������� �̸��� ���� ���� sprite��ü�� ��ȯ�ϵ��� �����ؾ��Ѵ�.
    /// </summary>
    /// <param name="item">������ ��ü</param>
    /// <returns></returns>
    private Sprite GetItemSprite(ItemSO item)
    {
        return _mockItemSprite;
    }
}
