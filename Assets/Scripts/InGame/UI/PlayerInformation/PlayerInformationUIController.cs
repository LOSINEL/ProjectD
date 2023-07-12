using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerInformationWindow;
    private bool IsInformationWindowOpen {
        get { 
            return _playerInformationWindow.activeSelf; 
        }
    }

    public void OpenInformationWindow()
    {
        _playerInformationWindow.SetActive(true);
    }

    public void CloseInformationWindow()
    {
        _playerInformationWindow.SetActive(false);
    }
}
