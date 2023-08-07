using UnityEngine;

[CreateAssetMenu]
public class MonsterSO : ScriptableObject
{
    [SerializeField] string monsterName;
    [SerializeField] int damage;
    [SerializeField] int maxHp;
    [SerializeField] int defense;
    [SerializeField] float attackSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isGround;
    [SerializeField] bool isMeleeAttack;
    [SerializeField] Enums.MONSTER_TYPE monsterType;
    [SerializeField] DropItem[] dropItems;
    [SerializeField] int gold;

    public string MonsterName { get { return monsterName; } }
    public int Damage { get { return damage; } }
    public int MaxHp { get { return maxHp; } }
    public int Defense { get { return defense; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float MoveSpeed { get { return moveSpeed * Nums.moveSpeedBasic; } }
    public bool IsGround { get { return isGround; } }
    public bool IsMeleeAttack { get { return isMeleeAttack; } }
    public Enums.MONSTER_TYPE MonsterType { get { return monsterType; } }
    public DropItem[] DropItems { get { return dropItems; } }
    public int Gold { get { return (int)Random.Range(gold * 0.75f, gold * 1.4f); } }

    [System.Serializable]
    public class DropItem
    {
        [SerializeField] Enums.ITEM_GRADE itemGrade;
        [SerializeField] float dropPercentage;

        public Enums.ITEM_GRADE ItemGrade { get { return itemGrade; } }
        public bool IsDropItem { get { if (Random.Range(0f, 1f) <= dropPercentage) return true; else return false; } }
    }
}