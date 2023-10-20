using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOffset : MonoBehaviour
{
    void Start()
    {
        OffsetObstacles();
    }

    private void OffsetObstacles()
    {
        Vector3 playerPosition = PlayerMovement.instance.transform.position;
        float magnitude = playerPosition.magnitude;
        transform.position += Vector3.up * magnitude;      
    }
}
