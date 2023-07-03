using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(Strings.tag_Ground))
        {
            controller.SetCanJump(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Strings.tag_Ground))
        {
            controller.SetCanJump(false);
        }
    }
}