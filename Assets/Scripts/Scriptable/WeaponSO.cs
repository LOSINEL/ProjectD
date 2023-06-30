using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponSO : EquipmentSO
{
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;

    public float Damage { get { return damage; } }
    public float AttakcSpeed { get { return attackSpeed; } }
}