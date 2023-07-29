using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Strings.tag_Player))
        {
            GetComponentInParent<Monster>().CheckAttackTF(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Strings.tag_Player))
        {
            GetComponentInParent<Monster>().CheckAttackTF(false);
        }
    }
}