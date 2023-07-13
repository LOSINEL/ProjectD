using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform tr;
    Rigidbody rigid;
    Animator animator;
    [SerializeField] bool canJump = true;
    [SerializeField] bool canJump2 = false;
    bool restoreSp = false;
    Coroutine restoreSp_IE;

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
        if (h < 0) transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        else if (h > 0) transform.rotation = Quaternion.Euler(Vector3.zero);
        if (IsSprint(h))
        {
            h *= Nums.sprintSpeed;
            if (restoreSp)
            {
                restoreSp = false;
                StopCoroutine(restoreSp_IE);
            }
        }
        else
        {
            if (!restoreSp)
                restoreSp_IE = StartCoroutine(RestoreStamina());
        }
        tr.Translate(new Vector3(h, 0, 0) * Player.instance.Data.MoveSpeed * Time.deltaTime, Space.World);
    }

    IEnumerator RestoreStamina()
    {
        while (true)
        {
            restoreSp = true;
            Player.instance.RecoverSp(Nums.staminaRecovery * Time.deltaTime);
            yield return null;
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
                rigid.velocity = Vector3.up * Player.instance.Data.JumpPower;
                canJump = false;
                canJump2 = true;
            }
            else if (canJump2)
            {
                rigid.velocity = Vector3.up * Player.instance.Data.JumpPower;
                canJump2 = false;
            }
        }
    }

    public void SetCanJump(bool tf) => canJump = tf;
    public void SetCanJump2(bool tf) => canJump2 = tf;
}