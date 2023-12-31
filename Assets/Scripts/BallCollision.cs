using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    ParticleSystem explosionVFX;
    int ballIndex;

    private void Start()
    {
        if (transform.GetChild(0).TryGetComponent(out explosionVFX)) { }
        else
            Debug.LogError("explosionVFX (ParticleSystem component) is not added.");
        // If x value of the ball is lower then 0 it is Blue ball, index 0.
        ballIndex = transform.position.x < 0 ? 0 : 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Obstacle"))
        {
            GameManager.instance.SetState(GameManager.State.GameOver);  
            explosionVFX.Play();
            if(other.collider != null)
            {
                Transform obstacleTransformParent = other.collider.transform.parent;
                SplatterManager.instance.AddSplatter(obstacleTransformParent, other.GetContact(0).point, ballIndex);
                obstacleTransformParent.GetComponent<SplatterCountHandler>().HandleSplatter();
            }           
            PlayerMovement.instance.Restart();
        }
    }
}
