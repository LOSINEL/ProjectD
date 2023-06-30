using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform tr;
    Rigidbody rigid;
    Animator animator;
    [SerializeField] bool canJump = true;

    private void Awake()
    {
        tr = transform;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger(Strings.animation_Attack);
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h == 0f)
        {
            RestoreStamina();
            return;
        }
        if (IsSprint()) h *= 1.5f;
        tr.Translate(new Vector3(h, 0, 0) * Player.instance.Data.GetStat(Enums.STAT_TYPE.MVSPD).StatValue * Time.deltaTime);
    }

    void RestoreStamina()
    {
        if (Player.instance.Data.GetStat(Enums.STAT_TYPE.NSTAMINA).StatValue < Player.instance.Data.GetStat(Enums.STAT_TYPE.MSTAMINA).StatValue)
            Player.instance.Data.AddStat(Enums.STAT_TYPE.NSTAMINA, Nums.staminaRecovery * Time.deltaTime);
    }

    bool IsSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Player.instance.Data.GetStat(Enums.STAT_TYPE.NSTAMINA).StatValue > 0f)
        {
            Player.instance.Data.SubStat(Enums.STAT_TYPE.NSTAMINA, Time.deltaTime * Nums.sprintStamina);
            return true;
        }
        else return false;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rigid.AddForce(Vector3.up * Player.instance.Data.GetStat(Enums.STAT_TYPE.JUMP_POWER).StatValue, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Strings.tag_Ground))
        {
            canJump = true;
        }
    }
}