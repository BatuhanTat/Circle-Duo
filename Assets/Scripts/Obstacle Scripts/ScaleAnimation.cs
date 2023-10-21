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

        //trailRenderer = GetComponent<TrailRenderer>();

        //trail_OriginalScale = trailRenderer.startWidth;
        //trail_TargetScale = trail_OriginalScale * scaleMultiplier;

        //DOTween.To(() => originalScale.x, (value) => trailRenderer.startWidth = value, targetScale.x, duration)
        //     .SetEase(Ease.InOutSine)
        //     .SetDelay(0.02f)
        //     .SetLoops(-1, LoopType.Yoyo);
    }


}
