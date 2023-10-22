using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterCountHandler : MonoBehaviour
{
    [SerializeField] int splatterCountLimit = 2;
    private List<GameObject> splatterList = new List<GameObject>();

    public void HandleSplatter()
    {
        // Find all child objects with the "Splatter" tag
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        List<Transform> splatterTransforms = new List<Transform>();

        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.CompareTag("Splatter"))
            {
                splatterTransforms.Add(childTransform);
            }
        }

        // Check if the splatterCountLimit has been reached
        if (splatterTransforms.Count > splatterCountLimit)
        {
            // If the limit is reached, remove the oldest splatter
            Transform oldestSplatter = splatterTransforms[0];
            splatterTransforms.RemoveAt(0);
            Destroy(oldestSplatter.gameObject);
        }
    }
}
