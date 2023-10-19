using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform targetTransform;

    void Start()
    {
        targetTransform = PlayerMovement.instance.transform;
    }

    private void LateUpdate()
    {
        transform.position = targetTransform.position;  
    }
}
