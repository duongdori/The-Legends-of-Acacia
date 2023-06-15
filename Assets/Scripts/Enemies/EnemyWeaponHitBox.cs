using System;
using UnityEngine;

public class EnemyWeaponHitBox : MonoBehaviour
{
    public EnemyWeapon enemyWeapon;
    
    private void Awake()
    {
        enemyWeapon = GetComponentInParent<EnemyWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        enemyWeapon.AttackDetected(col);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        enemyWeapon.RemoveFromDetected(col);
    }
}