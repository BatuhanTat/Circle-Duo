using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ObstacleSliding : ObstacleBase
{
    [SerializeField] float slideDistance;
    [SerializeField] float slideDuration;

    void Start()
    {
        ExecuteObstacle_Behaviour();
    }

    public override void ExecuteObstacle_Behaviour()
    {
        transform
             .DOLocalMoveX(slideDistance, slideDuration)
             .SetLoops(-1, LoopType.Yoyo)
             .SetEase(Ease.Linear);       
    }
}
