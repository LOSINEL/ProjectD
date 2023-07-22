using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlotList : MonoBehaviour
{
    private List<Image> _itemImageList;

    void Start()
    {
        FindAllItemImage();
    }

    private void FindAllItemImage()
    {
        _itemImageList = new();
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.transform.parent != gameObject.transform)
            {
                _itemImageList.Add(image);
            }
        }
    }

    public void ShowItemList(List<EquipmentSO> itemList)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Sprite sprite = itemList[i].ItemSprite;
            if(sprite == null) 
            {
                _itemImageList[i].enabled = false;
            }
            else 
            {
                _itemImageList[i].enabled = true;
                _itemImageList[i].sprite = sprite;
            }
        }
    }
}
