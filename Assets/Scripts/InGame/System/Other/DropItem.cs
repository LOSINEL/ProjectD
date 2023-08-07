using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IInteractable
{
    [SerializeField] ItemSO item;
    [SerializeField] ParticleSystemRenderer particle;

    public void Init(Enums.ITEM_GRADE ItemGrade)
    {
        item = ItemManager.instance.GetRandomItem(ItemGrade);
        particle.material = EffectManager.instance.ItemBoxMaterials[(int)ItemGrade];
    }

    public void Interact()
    {
        Destroy(this.gameObject);
    }
}