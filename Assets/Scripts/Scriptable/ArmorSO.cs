using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArmorSO : EquipmentSO
{
    [SerializeField] float defense;
    [SerializeField] float moveSpeed;

    public float Defense { get { return defense; } }
    public float MoveSpeed { get { return moveSpeed; } }
}