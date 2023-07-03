using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.InGame.UI.GameSettings;

public class GameSettingsController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameSettingsWindow;
    [SerializeField]
    private AbstractGameSettingController[] _controllers;
    [SerializeField]
    private Dictionary<Enums.GAME_SETTING_TYPE, IGameSettingReadable> _gameSettings;

    public bool IsGameSettingsWindowOn
    {
        get
        {
            return _gameSettingsWindow.activeSelf;
        }
    }

    private void Start()
    {
        _controllers = _gameSettingsWindow.GetComponentsInChildren<AbstractGameSettingController>();

        _gameSettings = new Dictionary<Enums.GAME_SETTING_TYPE, IGameSettingReadable>();
        foreach (AbstractGameSettingController controller in _controllers)
        {
            Enums.GAME_SETTING_TYPE settingType = controller.GetGameSettingType();
            if (_gameSettings.ContainsKey(settingType)) continue;

            _gameSettings[settingType] = (IGameSettingReadable)controller;
        }
    }

    public void OpenGameSettingsWindow()
    {
        _gameSettingsWindow.SetActive(true);
    }

    public void CloseGameSettingsWindow()
    {
        _gameSettingsWindow.SetActive(false);
    }

    public float GetBGMVolumn()
    {
        return (float)GetSettingValue(Enums.GAME_SETTING_TYPE.BGM_VOLUMN);
    }

    private object GetSettingValue(Enums.GAME_SETTING_TYPE settingType)
    {
        return _gameSettings[settingType].GetValue();
    }
}
