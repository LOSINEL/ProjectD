using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    private static InGameUIController _instance;

    [SerializeField]
    private PlayerInformationUIController _playerInformationUIController;

    [SerializeField]
    private GameSettingsController _gameSettingsController;
    public InGameUIController Instance
    {
        get { return _instance; }
    }

    public bool IsInGameUIOpen{
        get {
            return _playerInformationUIController.IsPlayerInformationPopupOpen;
        }
    }

    public bool IsInGameUIClosed {
        get{
            return !IsInGameUIOpen;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInGameUIClosed)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_playerInformationUIController.IsPlayerInformationPopupClosed)
                {
                    _playerInformationUIController.OpenInformationPopup();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameSettingsController.IsGameSettingsWindowOn)
            {
                _gameSettingsController.CloseGameSettingsWindow();
            }
        }
    }
}
