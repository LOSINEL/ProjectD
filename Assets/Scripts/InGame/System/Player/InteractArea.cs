using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    [SerializeField] List<GameObject> objects = new();

    private void Update()
    {
        if (objects.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && objects[0].TryGetComponent(out IInteractable tmp))
            {
                tmp.Interact();
                objects.Remove(objects[0]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Strings.tag_Npc) || other.CompareTag(Strings.tag_DropItem))
        {
            objects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Strings.tag_Npc) || other.CompareTag(Strings.tag_DropItem))
        {
            objects.Remove(other.gameObject);
        }
    }
}