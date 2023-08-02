using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IInteractable
{
    ItemSO item;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Init(Enums.ITEM_GRADE.LEGENDARY);
    }

    public void Init(Enums.ITEM_GRADE ItemGrade)
    {
        item = ItemManager.instance.GetRandomItem(ItemGrade);
    }

    public void Interact()
    {
        Debug.Log(item);
        // Inventory.instance.AcquireItem(item);
        // Destroy(this.gameObject);
    }
}