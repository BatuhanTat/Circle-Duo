using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    float activateDelay = 0.4f;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        ActivateTrailRenderer_WithDelay();
    }

    public void ActivateTrailRenderer_WithDelay()
    {
        if (trailRenderer != null)
        {
            Debug.Log("Before delay");
            trailRenderer.enabled = false;
            StartCoroutine(ActivateDelay());
        }
    }
    private IEnumerator ActivateDelay()
    {
        yield return new WaitForSeconds(activateDelay);
        Debug.Log("After delay");
        trailRenderer.enabled = true;
    }

    public abstract void ExecuteObstacle_Behaviour();

}
