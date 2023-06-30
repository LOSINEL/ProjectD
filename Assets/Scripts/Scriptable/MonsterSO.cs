using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSO : MonoBehaviour
{
    [SerializeField] string monsterName;
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    [SerializeField] float maxHp;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isBoss;
    [SerializeField] DropItem[] dropItems;

    public string MonsterName { get { return monsterName; } }
    public float Damage { get { return damage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float MaxHp { get { return maxHp; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public bool IsBoss { get { return isBoss; } }

    public class DropItem
    {
        [SerializeField] ItemSO item;
        [SerializeField] float dropPercentage;
    }
}