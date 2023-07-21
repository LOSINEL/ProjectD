using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    [SerializeField] GameObject particle;


    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void ActivateWeapon()
    {
        boxCollider.enabled = true;
    }

    public void DeactivateWeapon()
    {
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Strings.tag_Monster))
        {
            other.GetComponent<Monster>().GetDamaged(Player.instance.Data.Damage);
            Instantiate(particle, other.transform.position, Quaternion.identity);
        }
    }
}