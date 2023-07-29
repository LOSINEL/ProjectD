using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] protected MonsterSO monsterData;

    float nowHp;
    protected bool enemyCheck = false;
    protected bool attackCheck = false;
    protected Animator animator;
    protected Rigidbody rigid;
    protected Transform tr;

    public int Damage { get { return monsterData.Damage; } }

    private void Awake()
    {
        tr = transform;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        nowHp = monsterData.MaxHp;
    }

    public void CheckEnemy()
    {
        enemyCheck = true;
    }

    public void CheckAttackTF(bool tf)
    {
        attackCheck = tf;
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
        // DropItems();
        gameObject.SetActive(false);
    }

    void DropItems()
    {
        int count = monsterData.DropItems.Length;
        for (int i = 0; i < count; i++)
        {
            if (monsterData.DropItems[i].IsDropItem)
            {
                // GameObject tmpObj = Instantiate(dropItem, Vector3.zero, Quaternion.identity);
                // tmpObj.GetComponent<DropItem>().SetItem(monsterData.DropItems[i].Item);
                // Inventory.instance.AcquireItem(monsterData.Dropitems[i].Item);
            }
        }
    }
}