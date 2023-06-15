using UnityEngine;

public class EnemyWeaponAnimation : MonoBehaviour
{
    public EnemyWeapon enemyWeapon;
    
    private void Start()
    {
        enemyWeapon = GetComponentInParent<EnemyWeapon>();
    }
    
    private void AnimationFinishTrigger()
    {
        enemyWeapon.AnimationFinishTrigger();
    }
    
    private void AnimationActionTrigger()
    {
        enemyWeapon.AnimationActionTrigger();
    }
}