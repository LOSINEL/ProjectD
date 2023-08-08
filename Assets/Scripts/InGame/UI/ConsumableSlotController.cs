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

    private void Start()
    {
        _consumableSlotImage = GetComponent<Image>();
    }

    public void UpdateConsumableCountText(int count = 0, int maxCount = 0)
    {
        _consumableSlotLabel.text = $"{count}/{maxCount}";
    }

    public void ChangeConsumableSlotImage(Sprite sprite)
    {
        _consumableSlotImage.sprite = sprite;
    }
}
