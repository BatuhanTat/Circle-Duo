using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetTestTransform;
    Transform targetTransform;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
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
        targetPos.y += 3.4f;
        transform.position = targetPos;

    }
}
