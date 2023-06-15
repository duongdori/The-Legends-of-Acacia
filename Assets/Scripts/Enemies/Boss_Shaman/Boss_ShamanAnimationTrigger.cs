using System;
using UnityEngine;

public class Boss_ShamanAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Boss_Shaman enemy;

    private BoxCollider2D bossCol;

    private void Start()
    {
        enemy = GetComponentInParent<Boss_Shaman>();
        bossCol = GetComponent<BoxCollider2D>();
    }

    //Call from animation event
    private void AnimationFinishTrigger() => enemy.AnimationFinishTrigger();
    
    //Call from animation event
    private void AnimationTrigger() => enemy.AnimationTrigger();

    private void AttackTrigger()
    {
        bossCol.enabled = !bossCol.enabled;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            enemy.Stats.DoDamage(player.Stats);
        }
    }
}