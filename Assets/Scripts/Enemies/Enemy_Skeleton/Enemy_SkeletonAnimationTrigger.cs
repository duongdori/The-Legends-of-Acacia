using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Enemy_Skeleton enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy_Skeleton>();
    }

    //Call from animation event
    private void AnimationFinishTrigger() => enemy.AnimationFinishTrigger();
    
    //Call from animation event
    private void AnimationTrigger() => enemy.AnimationTrigger();

    private void AttackTrigger() => enemy.AttackTrigger();
}
