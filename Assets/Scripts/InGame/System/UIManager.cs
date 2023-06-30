using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool UIOpened { get { return false; } } // 인벤토리, 캐릭터 정보 등의 UI 열려있는지 체크 | ESC 눌렀을 때 닫히게 하기 위함
    public bool CanControl { get { return true; } } // 옵션창 열려있거나 NPC 대화중에는 조작 불가

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
    }

    void OpenInventoryWindow()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
        }
    }

    void OpenCharacterInfoWindow()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
        }
    }

    void OpenMapWindow()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
        }
    }

    void CloseWindow()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
    }
}