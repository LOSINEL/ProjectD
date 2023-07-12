using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    Transform tr;

    private void Awake()
    {
        tr = transform;
    }

    private void LateUpdate()
    {
        tr.position = Player.instance.transform.position + new Vector3(0f, 0f, -10f);
    }
}