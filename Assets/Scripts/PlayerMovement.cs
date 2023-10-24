using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton class : PlayerMovement

    public event EventHandler OnWin;
    public event EventHandler OnRestart;
    public static PlayerMovement instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);;
    }
    #endregion

    [Header("Ball Colliders")]
    [SerializeField] CircleCollider2D blueBallCollider;
    [SerializeField] CircleCollider2D redBallCollider;

    [Header("Speed parameters")]
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Camera mainCamera;
    private float touchPosX;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        MoveUpwards();
    }

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            // Mobile Inputs. Touch on screen sides.
            if (Input.GetMouseButtonDown(0))
            {
                touchPosX = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
                Debug.Log($"x position: {touchPosX}");
            }


            if (Input.GetMouseButton(0))
            {
                if (touchPosX > 0.01f)
                    RotateRight();
                else
                    RotateLeft();
            }
            else
                rb.angularVelocity = 0.0f;
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftArrow))
                RotateLeft();
            else if (Input.GetKey(KeyCode.RightArrow))
                RotateRight();

            // Stop rotation when the key is released
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                rb.angularVelocity = 0.0f;
#endif
        }

    }

    void MoveUpwards()
    {
        rb.velocity = Vector2.up * speed;
    }
    void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }
    void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }

    public void Restart()
    {
        OnRestart?.Invoke(this, EventArgs.Empty);   
        // Disabling the colliders so that new collisions will not be happened
        // while balls coming back to the initial position & rotation.
        redBallCollider.enabled = false;
        blueBallCollider.enabled = false;
        rb.angularVelocity = 0.0f;
        rb.velocity = Vector2.zero;

        // Animation
        transform.DORotate(Vector3.zero, 1.0f)
          .SetDelay(1.0f)
          .SetEase(Ease.InOutBack);

        transform.DOMove(startPosition, 1.0f)
            .SetDelay(1.0f)
            .SetEase(Ease.OutFlash)
             .OnComplete(() =>
             {
                 redBallCollider.enabled = true;
                 blueBallCollider.enabled = true;
                 GameManager.instance.isGameOver = false;
                 MoveUpwards();
             });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            GameManager.instance.isGameOver = true;
            Destroy(other.gameObject);
            OnWin?.Invoke(this, EventArgs.Empty);
            UpdatePosition();         
            //Debug.Log($"Start position: {startPosition}");
        }
    }

    public void RestartRotation()
    {
        rb.angularVelocity = 0.0f;
        transform.DORotate(Vector3.zero, 1.0f)
           .SetEase(Ease.InOutBack)
           .OnComplete(() =>
           {
               GameManager.instance.isGameOver = false;
           });
    }

    public void UpdatePosition()
    {
        startPosition = transform.position;
    }
}
