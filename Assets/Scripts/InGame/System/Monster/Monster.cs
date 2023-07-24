using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] MonsterSO monsterData;

    float nowHp;
    bool enemyCheck = false;

    public int Damage { get { return monsterData.Damage; } }

    private void Awake()
    {
        nowHp = monsterData.MaxHp;
    }

    public void CheckEnemy()
    {
        enemyCheck = true;
    }

    public void GetDamaged(int damage)
    {
        CheckEnemy();
        int tmpDmg = damage - monsterData.Defense;
        if (tmpDmg < 0) tmpDmg = 0;
        if (nowHp - tmpDmg <= 0)
        {
            Die();
        }
        else
        {
            nowHp -= tmpDmg;
        }
    }

    void Die()
    {
        // Inventory.instance.AddGold(monsterData.Gold);
        gameObject.SetActive(false);
    }
}