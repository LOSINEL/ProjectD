using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableSlotController : MonoBehaviour
{
    [SerializeField]
    private Image _consumableSlotImage;
    [SerializeField]
    private Text _consumableSlotLabel;

    /// <summary>
    /// ������ �������� ���ڷ� �޾� ȭ�鿡 �������� �̹����� �̸��� �����ش�.<br/>
    /// 
    /// TODO<br/>
    /// �׽�Ʈ�� ���ؼ� ���Ƿ� ���� ��������Ʈ�� �ؽ�Ʈ�� ȭ�鿡 �����ֵ��� �����ߴ�.
    /// </summary>
    /// <param name="item"></param>
    public void UpdateConsumableSlot(ItemSO item = null)
    {
        Sprite sprite = GetItemSprite(item);
        _consumableSlotImage.sprite = sprite;

        //_consumableSlotLabel.text = item.ItemName
        _consumableSlotLabel.text = "test###";
    }

    /// <summary>
    /// TODO
    /// �׽�Ʈ�� ���� �Ͼ� ��������Ʈ�� ������ ��ȯ�ϵ��� ������.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Sprite GetItemSprite(ItemSO item = null)
    {
        return Sprite.Create(Texture2D.whiteTexture, Rect.MinMaxRect(0, 0, 1, 1), Vector2.zero);
    }
}
