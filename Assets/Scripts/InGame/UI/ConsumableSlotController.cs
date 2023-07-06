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
    /// 착용한 아이템을 인자로 받아 화면에 아이템의 이미지와 이름을 보여준다.<br/>
    /// 
    /// TODO<br/>
    /// 테스트를 위해서 임의로 만든 스프라이트와 텍스트를 화면에 보여주도록 구현했다.
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
    /// 테스트를 위해 하얀 스프라이트를 생성해 반환하도록 설정함.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Sprite GetItemSprite(ItemSO item = null)
    {
        return Sprite.Create(Texture2D.whiteTexture, Rect.MinMaxRect(0, 0, 1, 1), Vector2.zero);
    }
}
