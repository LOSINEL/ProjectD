using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts.InGame.UI.GameSettings;

public class SliderController : AbstractGameSettingController, IGameSettingReadable
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Text _sliderValueText;

    protected override void AddListener()
    {
        _slider.onValueChanged.AddListener(delegate
        {
            _sliderValueText.text = $"{_slider.value}";
        });
    }

    protected override void Initialize()
    {
        _sliderValueText.text = $"{_slider.value}";
    }

    public object GetValue()
    {
        return _slider.value;
    }
}
