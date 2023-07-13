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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Strings.tag_Ground))
        {
            controller.SetCanJump(true);
            controller.SetCanJump2(false);
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