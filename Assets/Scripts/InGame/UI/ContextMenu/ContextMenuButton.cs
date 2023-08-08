using System;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts.InGame.UI.ContextMenu;

public class ContextMenuButton : MonoBehaviour
{
    public Button _button;
    public Text _text;

    void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
    }

    public void Initialize(IContextMenu contextMenu)
    {
        AddOnClickListener(contextMenu.OnSelect);
        SetLabel(contextMenu.GetLabel());
    }

    public void AddOnClickListener(Action contextMenuAction)
    {
        _button.onClick.AddListener(() =>
        {
            contextMenuAction();
            InGameContextMenuController.Instance.CloseContextMenu();
        });
    }

    public void SetLabel(string label)
    {
        _text.text = label;
    }

    public string GetLabel()
    {
        return _text.text;
    }
}
