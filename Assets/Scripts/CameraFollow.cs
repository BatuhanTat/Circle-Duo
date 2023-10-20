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
        Vector3 targetPos = targetTransform.position;
        // Offset
        targetPos.y += 3.2f;
        transform.position = targetPos;  
    }
}
