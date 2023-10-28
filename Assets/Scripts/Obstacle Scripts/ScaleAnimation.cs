using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] float scaleMultiplier;
    [SerializeField] float duration;
    private Vector3 originalScale;
    private Vector3 targetScale;

    //private TrailRenderer trailRenderer;
    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * scaleMultiplier;

        transform.DOScale(targetScale, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }


}
