using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool UIOpened { get { return false; } } // �κ��丮, ĳ���� ���� ���� UI �����ִ��� üũ | ESC ������ �� ������ �ϱ� ����
    public bool CanControl { get { return true; } } // �ɼ�â �����ְų� NPC ��ȭ�߿��� ���� �Ұ�

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