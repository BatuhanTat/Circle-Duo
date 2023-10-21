using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetTestTransform;
    Transform targetTransform;

    void Start()
    {
        targetTransform = PlayerMovement.instance.transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPos;
        if (targetTestTransform != null)
        {
            targetPos = targetTestTransform.position;
        }
        else
        { targetPos = targetTransform.position; }
        // Offset
        targetPos.y += 3.2f;
        transform.position = targetPos;
    }
}
