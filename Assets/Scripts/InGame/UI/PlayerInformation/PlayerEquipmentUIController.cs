using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts.InGame.System;

public class PlayerEquipmentUIController : MonoBehaviour
{
    private void Start()
    {
        IEquipmentObserver[] _equipmentObservers = GetComponentsInChildren<IEquipmentObserver>();

        foreach (IEquipmentObserver observer in _equipmentObservers)
        {
            observer.Initialize(InventoryManager.instance);
        }
    }
}
