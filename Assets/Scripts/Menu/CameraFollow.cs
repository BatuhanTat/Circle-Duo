using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{

    public static CameraFollow instance { get; private set; }

    [SerializeField] Transform targetTestTransform;
    Transform targetTransform;
    float offset = 1.0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);    
    }

    void Start()
    {
        GameManager.instance.OnStateChanged += OnStateChanged_Offset;
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
        targetPos.y += offset;
        transform.position = targetPos;
    }

    private void OnStateChanged_Offset(object sender, System.EventArgs e)
    {
        switch (GameManager.instance.state)
        {
            case GameManager.State.Menu:
                Debug.Log("menudeyiz");
                DOTween.To(() => offset, x => offset = x, 1.0f, 1.0f);
                break;

            case GameManager.State.Play:
                Debug.Log("Playdeyiz");
                DOTween.To(() => offset, x => offset = x, 3.4f, 0.5f);
                break;
        }
     
    }
}
