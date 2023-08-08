using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerInformationPopup;
    public bool IsPlayerInformationPopupOpen {
        get { 
            return _playerInformationPopup.activeSelf; 
        }
    }

    public bool IsPlayerInformationPopupClosed
    {
        get { return _playerInformationPopup.activeSelf == false; }
    }

    public void OpenInformationPopup()
    {
        _playerInformationPopup.SetActive(true);
    }

    public void CloseInformationPopup()
    {
        _playerInformationPopup.SetActive(false);
    }
}
