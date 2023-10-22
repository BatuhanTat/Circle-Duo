using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [Header("Speed parameter")]
    [SerializeField] float downwardSpeed;

    private Rigidbody2D rb;
    private ObstacleOffset obstacleOffset;

    private void Start()
    {
        PlayerMovement.instance.OnRestart += Obstacle_OnRestart;
        rb = GetComponent<Rigidbody2D>();
        obstacleOffset = GetComponent<ObstacleOffset>();
        MoveDownwards();
    }

    void MoveDownwards()
    {
        rb.velocity = Vector2.down * downwardSpeed;
    }

    private void Obstacle_OnRestart(object sender, System.EventArgs e)
    {
        rb.angularVelocity = 0.0f;
        rb.velocity = Vector2.zero;
        Vector3 startPosition = obstacleOffset.startPosition;

        // Animation
        transform.DORotate(Vector3.zero, 1.0f)
          .SetDelay(1.0f)
          .SetEase(Ease.InOutBack);

        transform.DOMove(startPosition, 1.0f)
            .SetDelay(1.0f)
            .SetEase(Ease.OutFlash)
             .OnComplete(() =>
             {
                 MoveDownwards();
             });
    }
}
