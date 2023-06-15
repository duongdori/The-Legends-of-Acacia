using UnityEngine;
using UnityEngine.Serialization;

public class Enemy_GoblinAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Enemy_Goblin enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy_Goblin>();
    }

    //Call from animation event
    private void AnimationFinishTrigger() => enemy.AnimationFinishTrigger();
    
    //Call from animation event
    private void AnimationTrigger() => enemy.AnimationTrigger();

    private void AttackTrigger() => enemy.AttackTrigger();
}