using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOffset : MonoBehaviour
{
    public Vector3 startPosition { get; private set; }

    void Start()
    {
        OffsetObstacles();
    }

    private void OffsetObstacles()
    {
        Vector3 playerPosition = PlayerMovement.instance.transform.position;
        float magnitude = playerPosition.magnitude;
        transform.position += Vector3.up * magnitude;
        startPosition = transform.position;
    }
}
