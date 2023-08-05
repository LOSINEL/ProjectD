using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackCollider : MonoBehaviour
{
    Monster monster;
    int damage;

    private void Awake()
    {
        monster = GetComponentInParent<Monster>();
        damage = monster.Damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Strings.tag_Player))
        {
            other.GetComponent<Player>().GetDamaged(damage);
        }
    }
}