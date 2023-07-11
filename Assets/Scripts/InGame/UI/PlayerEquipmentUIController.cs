using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentUIController : MonoBehaviour
{
    [SerializeField]
    private Image _weaponImage;
    [SerializeField]
    private Image _armorImage;
    [SerializeField]
    private Image _accessoryImage;

    public void UpdateWeaponImage(WeaponSO weapon)
    {
        Sprite sprite = GetEquipmentImage(weapon);
        _weaponImage.sprite = sprite;
    }

    public void UpdateArmorImage(ArmorSO armor)
    {
        Sprite sprite = GetEquipmentImage(armor);
        _armorImage.sprite = sprite;
    }

    public void UpdateAccessoryImage(AccessorySO accessory)
    {
        Sprite sprite = GetEquipmentImage(accessory);
        _accessoryImage.sprite = sprite;
    }

    private Sprite GetEquipmentImage(EquipmentSO equipment)
    {
        return Sprite.Create(Texture2D.whiteTexture, Rect.MinMaxRect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
    }
}
