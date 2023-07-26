using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdate
{
    Transform tr;
    Rigidbody rigid;
    Animator animator;
    [SerializeField] bool canJump = true;
    [SerializeField] bool canJump2 = false;
    bool restoreSp = false;
    bool canAttack = true;
    float baseYRot;
    float attackCoolTime = 0f;
    Coroutine restoreSp_IE;

    private void Awake()
    {
        tr = transform;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        baseYRot = tr.eulerAngles.y;
    }

    private void Start()
    {
        GetComponent<IUpdate>().Register();
    }

    public void ManagedUpdate()
    {
        if (true)
        {
            Move();
            Jump();
            Attack();
        }
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            animator.SetFloat(Strings.anim_float_AttackSpeed, Mathf.Sqrt(Player.instance.Data.AttackSpeed));
            animator.SetTrigger(Strings.animation_Attack);
            canAttack = false;
            attackCoolTime = 1f / Player.instance.Data.AttackSpeed;
        }
        if (!canAttack && attackCoolTime > 0f)
        {
            attackCoolTime -= Time.deltaTime;
        }
        else if (attackCoolTime <= 0f)
        {
            canAttack = true;
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw(Strings.moveHorizontal);
        if (h < 0) tr.rotation = Quaternion.Euler(new Vector3(0f, baseYRot + 180f, 0f));
        else if (h > 0) tr.rotation = Quaternion.Euler(new Vector3(0f, baseYRot, 0f));
        else
        {
            animator.SetBool(Strings.animation_Move, false);
            return;
        }
        animator.SetBool(Strings.animation_Move, true);
        if (IsSprint(h))
        {
            animator.SetBool(Strings.animation_Move, true);
            animator.SetFloat(Strings.anim_float_MoveSpeed, Nums.sprintSpeed);
            h *= Nums.sprintSpeed;
            if (restoreSp)
            {
                restoreSp = false;
                StopCoroutine(restoreSp_IE);
            }
        }
        else
        {
            animator.SetFloat(Strings.anim_float_MoveSpeed, 1f);
            if (!restoreSp)
                restoreSp_IE = StartCoroutine(RestoreStamina());
        }
        rigid.velocity = new Vector3(h * Player.instance.Data.MoveSpeed, rigid.velocity.y, 0);
    }

    IEnumerator RestoreStamina()
    {
        WaitForSeconds waitTime = new(Nums.spRecoverTime);
        while (true)
        {
            restoreSp = true;
            Player.instance.RecoverSp((Nums.basicSpRecovery + Player.instance.Data.SpRecovery) * Nums.spRecoverTime);
            yield return waitTime;
        }
    }

    bool IsSprint(float axis)
    {
        if (Input.GetKey(KeyCode.LeftShift) && Player.instance.NowSp > 0f && axis != 0f)
        {
            Player.instance.SubSp(Nums.sprintStamina * Time.deltaTime);
            return true;
        }
        else return false;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                animator.SetTrigger(Strings.animation_Jump);
                rigid.velocity = Vector3.up * Player.instance.Data.JumpPower;
                canJump = false;
                canJump2 = true;
            }
            else if (canJump2)
            {
                animator.SetTrigger(Strings.animation_Jump);
                rigid.velocity = Vector3.up * Player.instance.Data.JumpPower;
                canJump2 = false;
            }
        }
        animator.SetFloat(Strings.anim_float_VelocityY, rigid.velocity.y);
    }

    public void SetCanJump(bool tf) => canJump = tf;
    public void SetCanJump2(bool tf) => canJump2 = tf;
}