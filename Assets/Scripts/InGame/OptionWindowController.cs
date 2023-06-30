using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionWindowController : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionWindow;

    public bool isOptionWindowOn
    {
        get
        {
            return _optionWindow.activeSelf;
        }
    }

    public void OpenOptionWindow()
    {
        _optionWindow.SetActive(true);
    }

    public void CloseOptionWindow()
    {
        _optionWindow.SetActive(false);
    }
}
