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
        targetPos.y += 1.2f;
        transform.position = targetPos;  
    }
}
