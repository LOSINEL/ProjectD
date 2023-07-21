using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] PlayerData data;
    [SerializeField] int nowHp;
    [SerializeField] float nowSp;
    [SerializeField] bool isLiving = true;
    [SerializeField] MediKit mediKit;
    [SerializeField] PlayerWeapon playerWeapon;

    public PlayerData Data { get { return data; } }
    public int NowHp { get { return nowHp; } }
    public float NowSp { get { return nowSp; } }
    public MediKit MediKit { get { return mediKit; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        InitStat();
        StartCoroutine(RecoverHp());
    }

    IEnumerator RecoverHp()
    {
        WaitForSeconds waitTime = new WaitForSeconds(Nums.hpRecoverTime);
        while (true)
        {
            if (isLiving)
            {
                RecoverHp(UpgradeManager.instance.HpRecov);
            }
            yield return waitTime;
        }
    }

    void InitStat()
    {
        nowHp = data.MaxHp;
        nowSp = data.MaxSp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(Strings.tag_Monster))
        {
            GetDamaged(collision.transform.GetComponent<Monster>().Damage);
        }
    }

    public void RecoverHp(int hp)
    {
        if (nowHp + hp > data.MaxHp)
        {
            nowHp = data.MaxHp;
        }
        else
        {
            nowHp += hp;
        }
    }

    public void GetDamaged(int damage)
    {
        int tmpDmg = damage - data.Defense;
        if (tmpDmg < 0) tmpDmg = 0;
        if (nowHp - tmpDmg <= 0)
        {
            nowHp = 0;
            Die();
        }
        else
        {
            nowHp -= tmpDmg;
        }
    }

    public void SubSp(float sp)
    {
        if (nowSp - sp < 0f)
        {
            nowSp = 0f;
        }
        else
        {
            nowSp -= sp;
        }
    }

    void Die()
    {
        // die;
    }

    public void RecoverSp(float sp)
    {
        if (nowSp + sp > data.MaxSp)
        {
            nowSp = data.MaxSp;
        }
        else
        {
            nowSp += sp;
        }
    }

    public void ActivateWeapon()
    {
        playerWeapon.ActivateWeapon();
    }

    public void DeactivateWeapon()
    {
        playerWeapon.DeactivateWeapon();
    }

    [System.Serializable]
    public class PlayerData
    {
        [SerializeField] int damage;
        [SerializeField] int maxHp;
        [SerializeField] int defense;
        [SerializeField] float maxSp;
        [SerializeField] float attackSpeed;
        [SerializeField] float moveSpeed;
        [SerializeField] float jumpPower;

        public int Damage { get { return damage; } }
        public int MaxHp { get { return maxHp; } }
        public int Defense { get { return defense; } }
        public float MaxSp { get { return maxSp; } }
        public float AttackSpeed { get { return attackSpeed; } }
        public float MoveSpeed { get { return moveSpeed; } }
        public float JumpPower { get { return jumpPower; } }
    }
}