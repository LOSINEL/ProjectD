using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    [SerializeField] List<IInteractable> objects = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && objects.Count > 0)
        {
            objects[0].Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable tmp))
        {
            objects.Add(tmp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IInteractable tmp))
        {
            objects.Remove(tmp);
        }
    }
}