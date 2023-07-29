using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Ground_Melee : Monster, IUpdate
{
    bool randomMove = true;
    float moveTime = 0f;
    float idleTime = 0f;
    float stateTime = 0f;
    float attackTime = 0f;
    float attackCoolTime;
    bool canAttack = true;
    int stateNum;

    private void Start()
    {
        GetComponent<IUpdate>().Register();
        attackCoolTime = 1f / monsterData.AttackSpeed;
    }

    public void ManagedUpdate()
    {
        Move();
        if (attackCheck && canAttack)
        {
            Attack();
        }
        else
        {
            if (attackTime <= 0f)
            {
                canAttack = true;
            }
            else
            {
                attackTime -= Time.deltaTime;
            }
        }
    }

    void Move()
    {
        if (enemyCheck)
        {
            MoveToPlayer();
        }
        else
        {
            RandomMove();
            stateTime -= Time.deltaTime;
        }
    }

    void MoveToPlayer()
    {
        int tmp = (Player.instance.transform.position.x > tr.position.x) ? 1 : -1;
        Vector3 dir = rigid.velocity;
        dir.x = monsterData.MoveSpeed * tmp;
        rigid.velocity = dir;
        if (tmp > 0)
        {
            tr.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
        else
        {
            tr.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
    }

    void Attack()
    {
        animator.SetTrigger(Strings.animation_Attack);
        canAttack = false;
        attackTime = attackCoolTime;
    }

    void RandomMove()
    {
        if (stateTime <= 0f)
            stateNum = Random.Range(0, 3);
        Vector3 dir = rigid.velocity;
        switch (stateNum)
        {
            case 0: // idle
                if (stateTime <= 0f)
                    stateTime = Random.Range(Nums.monsterIdleTimeMin, Nums.monsterIdleTimeMax);
                break;
            case 1: // left move
                if (stateTime <= 0f)
                {
                    tr.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
                    stateTime = Random.Range(Nums.monsterMoveTimeMin, Nums.monsterMoveTimeMax);
                }
                dir.x = -monsterData.MoveSpeed;
                rigid.velocity = dir;
                break;
            case 2: // right move
                if (stateTime <= 0f)
                {
                    tr.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                    stateTime = Random.Range(Nums.monsterMoveTimeMin, Nums.monsterMoveTimeMax);
                }
                dir.x = monsterData.MoveSpeed;
                rigid.velocity = dir;
                break;
            default:break;
        }
    }
}
