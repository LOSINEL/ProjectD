using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSO : ItemSO
{
    [SerializeField] int equipmentCode;
    [SerializeField] Enums.ITEM_GRADE grade;

    public int Code { get { return equipmentCode; } }
    public Enums.ITEM_GRADE Grade { get { return grade; } }
}