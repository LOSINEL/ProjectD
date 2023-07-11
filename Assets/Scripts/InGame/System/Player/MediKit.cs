using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediKit : MonoBehaviour
{
    [SerializeField] int mediKitMaxNum;
    [SerializeField] int mediKitNum;
    [SerializeField] float healRatio;

    public int MediKitMaxNum { get { return mediKitMaxNum; } }
    public int MediKitNum { get { return mediKitNum; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseMediKit();
        }
    }

    void UseMediKit()
    {
        if (mediKitNum > 0)
        {
            mediKitNum--;
            Player.instance.RecoverHp((int)(Player.instance.Data.MaxHp * healRatio));
        }
    }

    public void UpgradeMediKit()
    {
        mediKitMaxNum++;
        mediKitNum++;
    }

    public void FillAllMediKit()
    {
        mediKitNum = mediKitMaxNum;
    }

    public void FillMediKit()
    {
        if (mediKitNum < mediKitMaxNum) mediKitNum++;
    }
}