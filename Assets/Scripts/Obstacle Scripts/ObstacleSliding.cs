using UnityEngine;
using DG.Tweening;

public class ObstacleSliding : MonoBehaviour, IObstacle
{
    [SerializeField] float slideDistance;
    [SerializeField] float slideDuration;

    void Start()
    {
        ExecuteObstacle_Behaviour();
    }

    public void ExecuteObstacle_Behaviour()
    {
        transform
             .DOLocalMoveX(slideDistance, slideDuration)
             .SetLoops(-1, LoopType.Yoyo)
             .SetEase(Ease.Linear);       
    }
}
