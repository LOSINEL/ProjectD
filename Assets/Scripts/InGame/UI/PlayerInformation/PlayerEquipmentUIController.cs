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
        _weaponImage.sprite = weapon.ItemSprite;
    }

    public void UpdateArmorImage(ArmorSO armor)
    {
        _armorImage.sprite = armor.ItemSprite;
    }

    public void UpdateAccessoryImage(AccessorySO accessory)
    {
        _accessoryImage.sprite = accessory.ItemSprite;
    }
}
