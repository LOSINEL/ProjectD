using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBarController : MonoBehaviour
{

    [SerializeField]
    private Image _healthImage;
    [SerializeField]
    private Text _healthText;
    [SerializeField]
    private Image _staminaImage;
    [SerializeField]
    private Text _staminaText;
    [SerializeField]
    private Text _levelText;

    public void UpdateHealthStatusBar(float health, float maxHealth)
    {
        float _fillAmount = (float)health / maxHealth;
        _healthImage.fillAmount = Mathf.Clamp01(_fillAmount);
        _healthText.text = $"{health} / {maxHealth}";
    }

    public void UpdateStaminaStatusBar(float stamina, float maxStamina)
    {
        float _fillAmount = (float)stamina / maxStamina;
        _staminaImage.fillAmount = Mathf.Clamp01(_fillAmount);
        _staminaText.text = $"{stamina} / {maxStamina}";
    }

    public void UpdateLevelText(int level)
    {
        _levelText.text = $"Level {level}";
    }
}
