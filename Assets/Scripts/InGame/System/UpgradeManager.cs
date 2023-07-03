using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public int HpRecov { get { return 1; } }

    private void Awake()
    {
        instance = this;
    }
}