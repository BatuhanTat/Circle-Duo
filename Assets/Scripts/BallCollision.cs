using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Obstacle"))
        {
            GameManager.instance.isGameOver = true;
            PlayerMovement.instance.Restart();
        }
    }
}
