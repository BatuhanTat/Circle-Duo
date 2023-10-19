using UnityEngine;
using DG.Tweening;

public class ObstacleRotating : MonoBehaviour, IObstacle
{
    [Tooltip("Duration of one full rotation.")]
    [SerializeField] float rotationDuration;

    void Start()
    {
        ExecuteObstacle_Behaviour();
    }
    
    public void ExecuteObstacle_Behaviour()
    {
        // Clockwise rotation
        transform
            .DORotate(new Vector3(0.0f, 0.0f, -1.0f), rotationDuration)
            .SetLoops(-1, LoopType.Incremental);
    }
}
