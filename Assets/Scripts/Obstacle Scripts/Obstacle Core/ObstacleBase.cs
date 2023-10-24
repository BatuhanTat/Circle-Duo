using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    float activateDelay = 0.4f;
    TrailRenderer[] trailRenderers;

    private void Awake()
    {
        trailRenderers = GetComponentsInChildren<TrailRenderer>(true);
        ActivateTrailRenderer_WithDelay();
    }

    public void ActivateTrailRenderer_WithDelay()
    {
        if (trailRenderers != null)
        {
                foreach (TrailRenderer trailRenderer in trailRenderers)
                {
                    // Disable each trailRenderer.
                    trailRenderer.enabled = false;
                }
                StartCoroutine(ActivateDelay());
        }
    }
    private IEnumerator ActivateDelay()
    {
        yield return new WaitForSeconds(activateDelay);
        foreach (TrailRenderer trailRenderer in trailRenderers)
        {
            // Enable each trailRenderer.
            trailRenderer.enabled = true;
        }
    }

    public abstract void ExecuteObstacle_Behaviour();

}
