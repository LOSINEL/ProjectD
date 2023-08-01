using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Ground_Melee : Monster, IUpdate
{
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Strings.animation_Attack)) return;
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
        animator.SetFloat(Strings.anim_float_VelocityX, Mathf.Abs(dir.x));
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
        {
            stateNum = Random.Range(0, 3);
        }
        Vector3 dir = rigid.velocity;
        switch (stateNum)
        {
            case 0: // idle
                if (stateTime <= 0f)
                    stateTime = Random.Range(Nums.monsterIdleTimeMin, Nums.monsterIdleTimeMax);
                dir.x = 0;
                rigid.velocity = dir;
                break;
            case 1: // left move
                RotateToMoveDir_Random(true);
                dir.x = -monsterData.MoveSpeed;
                rigid.velocity = dir;
                break;
            case 2: // right move
                RotateToMoveDir_Random(false);
                dir.x = monsterData.MoveSpeed;
                rigid.velocity = dir;
                break;
            default:break;
        }
        animator.SetFloat(Strings.anim_float_VelocityX, Mathf.Abs(dir.x));
    }

    void RotateToMoveDir_Random(bool isLeft)
    {
        int tmp = isLeft ? -1 : 1;
        if (stateTime <= 0f)
        {
            tr.rotation = Quaternion.Euler(new Vector3(0f, tmp * 90f, 0f));
            stateTime = Random.Range(Nums.monsterMoveTimeMin, Nums.monsterMoveTimeMax);
        }
    }
}